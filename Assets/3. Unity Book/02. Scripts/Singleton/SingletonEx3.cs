using UnityEngine;

// �̷��� �ۼ��ϸ� �ȵǴ� �ڵ�
public class SingletonEx3 : MonoBehaviour
{
    private static SingletonEx3 instance = new SingletonEx3(); // ���� ����
    public static SingletonEx3 Instance // ������Ƽ
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
