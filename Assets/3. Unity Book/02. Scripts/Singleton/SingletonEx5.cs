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
                var obj = FindFirstObjectByType<SingletonEx5>(); // 일단 찾기

                if (obj != null)
                    instance = obj;
                else
                {
                    var newObj = new GameObject("Singleton"); // Singleton이라는 이름의 오브젝트 생성
                    newObj.AddComponent<SingletonEx5>(); // 컴포넌트 추가

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
