using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    // ������Ƽ ���
    public static SingletonEx2 Instance
    {
        get; // ���� ����
        private set; // ���� �Ұ�
    }

    void Awake()
    {
        if (Instance == null) // Instance�� ��������� �ڽ�(this)�� �Ҵ�
        {
            Instance = this;
        }
        else // �̹� Singleton�� �����ϸ� this ��ũ��Ʈ �ı� -> �ߺ� ���� ����
        {
            Destroy(gameObject);
        }
    }
}
