using UnityEngine;

// 이렇게 작성하면 안되는 코드
public class SingletonEx3 : MonoBehaviour
{
    private static SingletonEx3 instance = new SingletonEx3(); // 내부 변수
    public static SingletonEx3 Instance // 프로퍼티
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonEx3();
            }

            return instance;
        }
    }
}
