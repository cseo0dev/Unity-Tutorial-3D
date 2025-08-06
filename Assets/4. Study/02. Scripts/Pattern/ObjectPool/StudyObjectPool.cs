using System.Collections.Generic;
using UnityEngine;

public class StudyObjectPool :  StudyGenericSingleton<StudyObjectPool>
{
    public Queue<GameObject> objQueue = new Queue<GameObject> (); // ������Ʈ�� �� Ǯ
    public GameObject objPrefab; // ������ ������Ʈ

    public int poolSize = 100;

    void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objPrefab, transform);
            EnqueueObject(newObj);
        }
    }

    public void EnqueueObject (GameObject obj) // ������Ʈ�� Ǯ�忡 �ִ� ���
    {
        objQueue.Enqueue(obj);
        obj.SetActive(false); // Ǯ�忡 ������ ȭ�鿡 ���̸� �ȵǹǷ� false
    }

    public GameObject DequeueObject() // ������Ʈ�� Ǯ�忡�� ������ ���
    {
        GameObject obj = objQueue.Dequeue();

        return obj;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (objQueue.Count < 10)
                CreateObject();

            GameObject obj = DequeueObject(); // Ǯ���� ������Ʈ�� ���� ���
            obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        }

        // ������ ������Ʈ���� ����ϴ� ���
        // StudyObjectPool.Instance.EnqueueObject(gameObject);
    }
}
