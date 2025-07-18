using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;
    
    void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 7) // 70%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position; // 플레이어를 바라보는 방향 값
            dir.Normalize();
        }
        else // 30%
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        //// 점수 증가
        //GameObject smObject = GameObject.Find("ScoreManager");
        //ScoreManager sm = smObject.GetComponent<ScoreManager>();

        //// sm.SetScore(sm.GetScore() + 1); // 책에 적힌 거
        //var score = sm.GetScore() + 1;
        //sm.SetScore(score);

        ScoreManager.Instance.Score++;

        // 파티클 생성
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // 파괴 기능
        // Destroy(other.gameObject);
        if (other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //player.bulletObjectPool.Add(other.gameObject); // pool 오브젝트를 제거해주었기 때문에 다시 추가해주어야 함
            // other.gameObject.SetActive(false); // 총알 오브젝트

            // 위 코드를 싱글톤/리스트로 구현
            // PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            
            //큐
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);

            other.gameObject.SetActive(false);
        }
        else
            // Destroy(gameObject); // Enemy 오브젝트
            Destroy(other.gameObject); // 플레이어 오브젝트

        // EnemyManager.Instance.enemyObjectPool.Add(gameObject); // 리스트
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject); // 큐
        gameObject.SetActive(false);
    }
}