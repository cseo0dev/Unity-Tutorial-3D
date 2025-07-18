using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed = 100f;
    public bool isMove = true;

    void Update()
    {
        if (isMove)
            transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    // 화살 박히는 거 구현
    private void OnTriggerEnter(Collider other)
    {
        var closetPos = other.ClosestPoint(transform.position);

        transform.position = closetPos;
        transform.SetParent(other.transform);
        isMove = false;
    }
}
