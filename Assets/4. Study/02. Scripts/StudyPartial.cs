using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    private int nuber; // ���� �̸� ���� X

    public void Start()
    {
        MethodA();
        MethodB();
    }
    private void MethodA()
    {
        Debug.Log("MethodA");
    }
}


public partial class StudyPartial : MonoBehaviour
{
    // private int nuber; // ���� �̸� ���� X

    // void Start() { }// �Լ� �̸� ���� X

    private void MethodB()
    {
        Debug.Log("MethodB");
    }
}
