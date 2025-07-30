using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    private float gravity = -20f; // �߷�
    private float yVelocity = 0f; // ���� �ӷ�

    public float jumpPower = 2f;
    public bool isJumping = false;

    public int hp = 20;

    private int maxHp = 20;
    public Slider hpSlider;

    public GameObject hitEffect;

    public Animator anim;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3 (h, 0, v);
        anim.SetFloat("MoveMotion", dir.magnitude);

        dir = dir.normalized;

        // ī�޶��� Transform �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        // �߷� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // ĳ���� ��Ʈ�ѷ��� ����� �̵� ���

        // �Ʒ��ʿ� ���� ���� ����
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
                isJumping = false;

            yVelocity = 0f;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            yVelocity = jumpPower;
        }
    }

    public void DamageAction(int damage)
    {
        hp -= damage;
        hpSlider.value = (float)hp / (float)maxHp;

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        Debug.Log("��Ʈ����Ʈ");
        hitEffect.SetActive(true);
        
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}
