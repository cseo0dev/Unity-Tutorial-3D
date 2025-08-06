using UnityEngine;
using UnityEngine.Pool;

public class StudyObjectPool2 : StudyGenericSingleton<StudyObjectPool2>
{
    public ObjectPool<GameObject> objPool;
    public GameObject objPrefab;

    void Awake()
    {
        objPool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);

        return obj;
    }

    private void GetObject(GameObject obj)
    {
        Debug.Log("풀에서 오브젝트 꺼내는 기능");
        obj.SetActive(true);
    }

    private void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        Debug.Log("풀에 오브젝트를 넣는 기능");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objPool.Get();
        }

        // 생성한 오브젝트에서 사용하는 기능
        // StudyObjectPool2.Instance.objPool.Release(gameObject);
    }
}
