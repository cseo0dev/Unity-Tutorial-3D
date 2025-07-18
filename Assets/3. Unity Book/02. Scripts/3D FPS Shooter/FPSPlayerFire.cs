using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;

    public float throwPower = 15f;

    public GameObject bulletEffect;
    private ParticleSystem ps;

    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            // 레이 생성 후 발사될 위치와 발사 방향 지정
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // 레이가 부딪힌 대상의 정보를 변수로 저장
            RaycastHit hitInfo = new RaycastHit();

            // 레이를 발사한 후 부딪힌 물체가 있는 경우 피격 이펙트 발동
            if (Physics.Raycast(ray, out hitInfo)) // 시작위치, 방향, out hitInfo, 거리
            {
                bulletEffect.transform.position = hitInfo.point; // 피격 이펙트가 부딪힌 대상의 위치로 이동
                bulletEffect.transform.forward = hitInfo.normal;
                ps.Play(); // 피격 이펙트 플레이
            }
        }

        // 수류탄 투척
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
