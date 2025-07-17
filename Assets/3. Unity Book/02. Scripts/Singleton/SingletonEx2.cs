using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    // 프로퍼티 기반
    public static SingletonEx2 Instance
    {
        get; // 접근 가능
        private set; // 수정 불가
    }

    void Awake()
    {
        if (Instance == null) // Instance가 비어있으면 자신(this)을 할당
        {
            Instance = this;
        }
        else // 이미 Singleton이 존재하면 this 스크립트 파괴 -> 중복 생성 방지
        {
            Destroy(gameObject);
        }
    }
}
