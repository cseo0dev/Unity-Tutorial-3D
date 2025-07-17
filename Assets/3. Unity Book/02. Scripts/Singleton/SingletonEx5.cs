using UnityEngine;

public class SingletonEx5 : MonoBehaviour
{
    private static SingletonEx5 instance;
    public static SingletonEx5 Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindFirstObjectByType<SingletonEx5>(); // �ϴ� ã��

                if (obj != null)
                    instance = obj;
                else
                {
                    var newObj = new GameObject("Singleton"); // Singleton�̶�� �̸��� ������Ʈ ����
                    newObj.AddComponent<SingletonEx5>(); // ������Ʈ �߰�

                    instance = newObj.GetComponent<SingletonEx5>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
