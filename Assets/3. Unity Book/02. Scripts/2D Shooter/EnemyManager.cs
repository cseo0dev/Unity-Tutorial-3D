using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    // public GameObject[] enemyObjectPool; // 배열
    // public List<GameObject> enemyObjectPool; // 리스트
    public Queue<GameObject> enemyObjectPool; // 큐

    public Transform[] spawnPoints;

    public GameObject enemyFactory;

    private float currentTime; // 타이머
    private float minTime = 1;
    private float maxTime = 5;
    public float createTime = 1f; // 생성 주기

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        //enemyObjectPool = new GameObject[poolSize];
        //enemyObjectPool = new List<GameObject>();
        enemyObjectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory); // SetActive(true)로 실행됨

            // enemyObjectPool[i] = enemy;
            // enemyObjectPool.Add(enemy);
            enemyObjectPool.Enqueue(enemy);

            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // 랜덤한 시간이 될 때마다 랜덤한 위치에 Enemy 생성
        {
            // 큐
            if (enemyObjectPool.Count > 0)
            {
                currentTime = 0f;
                createTime = Random.Range(minTime, maxTime);

                GameObject enemy = enemyObjectPool.Dequeue();

                int ranIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[ranIndex];

                enemy.transform.position = spawnPoint.position;
                enemy.SetActive(true);
            }

            // 리스트로 만든 Pool 사용하는 기능
            //if (enemyObjectPool.Count > 0)
            //{
            //    currentTime = 0f;
            //    createTime = Random.Range(minTime, maxTime);

            //    GameObject enemy = enemyObjectPool[0];
            //    enemyObjectPool.Remove(enemy);

            //    int ranIndex = Random.Range(0, spawnPoints.Length);
            //    Transform spawnPoint = spawnPoints[ranIndex];

            //    enemy.transform.position = spawnPoint.position;
            //    enemy.SetActive(true);
            //}

            //for (int i = 0; i < poolSize; i++)
            //{
            //    GameObject enemy = enemyObjectPool[i];
            //    if (!enemy.activeSelf)
            //    {
            //        int ranIndex = Random.Range(0, spawnPoints.Length);
            //        Transform spawnPoint = spawnPoints[ranIndex];

            //        enemy.transform.position = spawnPoint.position;
            //        enemy.SetActive(true);

            //        break;
            //    }
            //}
        }
    }
}