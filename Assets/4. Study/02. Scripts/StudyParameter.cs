using System.Collections.Generic;
using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    public int number = 1;
    public int number2;

    public GameObject player;
    public GameObject enemy;
    public GameObject item;

    public List<GameObject> objs = new List<GameObject>();

    void Start()
    {
        //NormalParameter(number);
        //Debug.Log($"Call by Value : {number}");

        //ReferenceParameter(ref number);
        //Debug.Log($"Call by Reference : {number}");

        //OutParameter(out number, out number2);
        //Debug.Log($"Call by Out : {number}, {number2}");

        //DefaultParameter(); // 값이 없어도 되고
        //DefaultParameter(5); // 있으면 해당 값으로 초기화 됨 number = 5

        //int[] inArray = new int[3] { 10, 20, 30 }; // 크기가 정해져 있어서 값 추가 안됨
        //ArrayParameter(inArray);

        //ParamsParameter(10, 20, 30);

        objs.Add(player);
        objs.Add(enemy);
        objs.Add(item);

        GameObjectActivate2(false, player, enemy, item);
    }

    #region 매개변수 방식
    // 일반적인 매개변수 -> Call by Value / 값 타입
    private void NormalParameter(int num)
    {
        num = 10;
        //num = 10;
        //number = num;
    }

    // 선택적 매개변수 (Default 매개변수) -> 매개변수에 값을 넣어둔 것
    private void DefaultParameter(int num = 3)
    {
        number = num;
    }

    // 참조 방식의 매개변수 -> Call by Reference / 참조 타입 / 수정의 개념
    private void ReferenceParameter(ref int num)
    {
        num = 20;
    }

    // 반환의 개념 / 인자를 초기화하지 않아도 사용 가능
    private void OutParameter(out int num, out int num2)
    {
        num = 30;
        num2 = 50;
    }

    // Collection을 매개변수로 넣은 경우
    private void ArrayParameter(int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    // params를 활용한 매개변수 -> 인자를 직접 넣어서 사용 가능
    private void ParamsParameter(params int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }
    private void GameObjectActivate() // 하나씩 다 끄거나 반복문 사용을 위해 리스트를 만들어야 함
    {
        // player.SetActive(false);
        // enemy.SetActive(false);
        // item.SetActive(false);

        foreach (var o in objs)
            o.SetActive(false);
    }

    private void GameObjectActivate2(bool isActive, params GameObject[] objs) // 파람스로 간결하게 가능
    {
        foreach (var o in objs)
            o.SetActive(isActive);
    }
    #endregion

    #region Overloading
    // 오버로딩 : 매개변수를 다르게 해서 다른 기능을 구현하는 방법
    private void OverloadingMethod() { Debug.Log("기능 A"); }
    private void OverloadingMethod(int num) { Debug.Log("기능 B"); }
    private void OverloadingMethod(float num) { Debug.Log("기능 C"); }
    private void OverloadingMethod(bool isNum) { Debug.Log("기능 D"); }
    private void OverloadingMethod(int num1, int num2) { Debug.Log("기능 E"); }
    #endregion

}
