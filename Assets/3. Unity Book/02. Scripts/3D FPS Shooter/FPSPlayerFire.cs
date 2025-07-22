using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    private Animator anim;
    private ParticleSystem ps;

    public float throwPower = 15f;
    public int weaponPower = 5;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        // �Ѿ� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            // ���� ���� �� �߻�� ��ġ�� �߻� ���� ����
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // ���̰� �ε��� ����� ������ ������ ����
            RaycastHit hitInfo = new RaycastHit();

            // ���̸� �߻��� �� �ε��� ��ü�� �ִ� ��� �ǰ� ����Ʈ �ߵ�
            if (Physics.Raycast(ray, out hitInfo)) // ������ġ, ����, out hitInfo, �Ÿ�
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) // Enemy ����
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // Enemy�� �ƴ� ��� �ǰ� ����Ʈ �÷���
                {
                    bulletEffect.transform.position = hitInfo.point; // �ǰ� ����Ʈ�� �ε��� ����� ��ġ�� �̵�
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play(); // �ǰ� ����Ʈ �÷���
                }
            }
        }

        // ����ź ��ô
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
