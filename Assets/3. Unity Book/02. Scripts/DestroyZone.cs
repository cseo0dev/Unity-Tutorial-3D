using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            // 리스트
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);

            // 큐
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else
        {
            // EnemyManager.Instance.enemyObjectPool.Add(other.gameObject);
            EnemyManager.Instance.enemyObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}