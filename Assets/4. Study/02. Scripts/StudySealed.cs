using UnityEngine;

public abstract class ParentClass : MonoBehaviour
{
    //public virtual void Method() // ���� �Լ� / Ư�� �Լ��� �����ϰ� ���� �� virtual ���
    //{
    //    Debug.Log("Parent Method");
    //}

    public abstract void Method(); // �߻� �Լ� -> Ŭ���� �տ� abstract �־�� ��
}

public class StudySealed : ParentClass
{
    public sealed override void Method() // �������̵��� �Լ�
    {
        // base.Method(); // �θ� Ŭ������ �Լ� ����� �������� �� / �߻� �Լ����� ����� �� ����
        Debug.Log("Override Method");
    }
}

//public class ChildClass : StudySealed
//{
//    public override void Method() // ���� Ŭ�������� sealed�� ���� �ֱ� ������ ��� �Ұ�
//    {

//    }
//}