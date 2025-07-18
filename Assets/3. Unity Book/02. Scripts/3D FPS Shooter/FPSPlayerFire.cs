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
        // �Ѿ� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            // ���� ���� �� �߻�� ��ġ�� �߻� ���� ����
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // ���̰� �ε��� ����� ������ ������ ����
            RaycastHit hitInfo = new RaycastHit();

            // ���̸� �߻��� �� �ε��� ��ü�� �ִ� ��� �ǰ� ����Ʈ �ߵ�
            if (Physics.Raycast(ray, out hitInfo)) // ������ġ, ����, out hitInfo, �Ÿ�
            {
                bulletEffect.transform.position = hitInfo.point; // �ǰ� ����Ʈ�� �ε��� ����� ��ġ�� �̵�
                bulletEffect.transform.forward = hitInfo.normal;
                ps.Play(); // �ǰ� ����Ʈ �÷���
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
