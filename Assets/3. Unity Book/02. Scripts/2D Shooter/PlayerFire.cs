#define DEBUG_TEST

using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    // public GameObject[] bulletObjectPool; // 배열
    // public List<GameObject> bulletObjectPool; // 리스트
    public Queue<GameObject> bulletObjectPool; // 큐

    void Start()
    {
        // bulletObjectPool = new GameObject[poolSize];
        // bulletObjectPool = new List<GameObject>();
        bulletObjectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            // bulletObjectPool[i] = bullet;
            // bulletObjectPool.Add(bullet);
            bulletObjectPool.Enqueue(bullet);

            bullet.SetActive(false);
        }
    }

    void Update()
    {
#if UNITY_STANDALONE ||UNITY_EDITOR || DEBUG_TEST
        if (Input.GetButtonDown("Fire1"))
        {
            // 큐
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("손가락 터치");

            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#endif
            // 리스트
            //if (bulletObjectPool.Count > 0)
            //{
            //    GameObject bullet = bulletObjectPool[0]; // 가져올 오브젝트 선택
            //    bullet.SetActive(true); // 오브젝트 사용
            //    bulletObjectPool.Remove(bullet); // Pool에서 오브젝트 제거
            //    bullet.transform.position = firePosition.transform.position;
            //}

            // 배열
            //for (int i = 0; i < poolSize; i++)
            //{
            //    GameObject bullet = bulletObjectPool[i];

            //    if (!bullet.activeSelf)
            //    {
            //        bullet.SetActive(true);
            //        bullet.transform.position = firePosition.transform.position;

            //        break;
            //    }
            //}
        }
    }
}