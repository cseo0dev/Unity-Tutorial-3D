using UnityEngine;

public abstract class ParentClass : MonoBehaviour
{
    //public virtual void Method() // 가상 함수 / 특정 함수를 봉인하고 싶을 때 virtual 사용
    //{
    //    Debug.Log("Parent Method");
    //}

    public abstract void Method(); // 추상 함수 -> 클래스 앞에 abstract 넣어야 함
}

public class StudySealed : ParentClass
{
    public sealed override void Method() // 오버라이드한 함수
    {
        // base.Method(); // 부모 클래스의 함수 기능을 가져오는 것 / 추상 함수에서 사용할 수 없음
        Debug.Log("Override Method");
    }
}

//public class ChildClass : StudySealed
//{
//    public override void Method() // 상위 클래스에서 sealed로 묶여 있기 때문에 사용 불가
//    {

//    }
//}