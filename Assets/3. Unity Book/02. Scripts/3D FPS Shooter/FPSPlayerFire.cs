using TMPro;
using UnityEngine;
using System.Collections;

public class FPSPlayerFire : MonoBehaviour
{
    private enum WeaponMode { Normal, Sniper };
    private WeaponMode wMode;

    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    private Animator anim;
    private ParticleSystem ps;

    public TextMeshProUGUI wModeText;

    public float throwPower = 15f;
    public int weaponPower = 5;

    private bool ZoomMode = false;

    public GameObject[] eff_Flash;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();

        wMode = WeaponMode.Normal;
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        // 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            // 레이 생성 후 발사될 위치와 발사 방향 지정
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // 레이가 부딪힌 대상의 정보를 변수로 저장
            RaycastHit hitInfo = new RaycastHit();

            // 레이를 발사한 후 부딪힌 물체가 있는 경우 피격 이펙트 발동
            if (Physics.Raycast(ray, out hitInfo)) // 시작위치, 방향, out hitInfo, 거리
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) // Enemy 감지
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // Enemy가 아닌 경우 피격 이펙트 플레이
                {
                    bulletEffect.transform.position = hitInfo.point; // 피격 이펙트가 부딪힌 대상의 위치로 이동
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play(); // 피격 이펙트 플레이
                }
            }

            StartCoroutine(ShootEffectOn(0.05f));
        }

        if (Input.GetMouseButtonDown(1))
        {
            switch (wMode)
            {
                // 노말모드 - 수류탄 투척
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

                    break;
                
                // 스나이퍼 모드 - 스나이퍼 줌 In/Out
                case WeaponMode.Sniper:
                    //if (!ZoomMode)
                    //{
                    //    Camera.main.fieldOfView = 15f;
                    //    ZoomMode = true;
                    //}
                    //else
                    //{
                    //    Camera.main.fieldOfView = 60f;
                    //    ZoomMode = false;
                    //}
                    float fov = ZoomMode ? 60f : 15f;
                    Camera.main.fieldOfView = fov;
                    ZoomMode = !ZoomMode;
                    
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;
            wModeText.text = "Normal Mode";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;
            wModeText.text = "Sniper Mode";
        }
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length - 1);
        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}
