using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    // �ܺ� ���� ���, ���ο��� ���� ����
    public static StudySingleton Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this; // ���� ��ü�� �̱��� �ν��Ͻ��� ����
        else
            Destroy(gameObject); // �ߺ� ���� ����
    }
}
