using UnityEngine;

public class SingletonEx1 : MonoBehaviour
{
    // static 변수 기반
    public static SingletonEx1 Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
