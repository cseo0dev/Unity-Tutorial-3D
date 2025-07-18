using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPos;
    public bool isShoot;

    void Update()
    {
        Ray ray = new(shootPos.position, shootPos.forward);
        RaycastHit hit;

        bool isTargeting = Physics.Raycast(ray, out hit);

        Debug.DrawRay(shootPos.position, shootPos.forward, Color.green); // 레이케스트 확인하기 1

        if (isTargeting && !isShoot)
            StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        //arrow.transform.position = shootPos.position;
        //arrow.transform.rotation = rot;
        arrow.transform.SetPositionAndRotation(shootPos.position, rot);

        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected() // 레이케스트 확인하기 2
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f);
    }
}
