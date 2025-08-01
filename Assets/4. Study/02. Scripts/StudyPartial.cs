using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    private int nuber; // 변수 이름 동일 X

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
    // private int nuber; // 변수 이름 동일 X

    // void Start() { }// 함수 이름 동일 X

    private void MethodB()
    {
        Debug.Log("MethodB");
    }
}
