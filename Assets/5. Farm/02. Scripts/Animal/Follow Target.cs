using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // 플레이어의 x축만 따라가도록
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
