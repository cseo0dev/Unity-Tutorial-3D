using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    private float gravity = -20f; // 중력
    private float yVelocity = 0f; // 수직 속력

    public float jumpPower = 10f;
    public bool isJumping = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3 (h, 0, v);
        dir = dir.normalized;

        // 카메라의 Transform 기준으로 변환
        dir = Camera.main.transform.TransformDirection(dir);

        // 중력 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // 캐릭터 컨트롤러에 내장된 이동 기능

        // 아래쪽에 무언가 닿은 상태
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
}
