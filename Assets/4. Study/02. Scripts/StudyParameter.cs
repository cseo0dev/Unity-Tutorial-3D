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

        //DefaultParameter(); // ���� ��� �ǰ�
        //DefaultParameter(5); // ������ �ش� ������ �ʱ�ȭ �� number = 5

        //int[] inArray = new int[3] { 10, 20, 30 }; // ũ�Ⱑ ������ �־ �� �߰� �ȵ�
        //ArrayParameter(inArray);

        //ParamsParameter(10, 20, 30);

        objs.Add(player);
        objs.Add(enemy);
        objs.Add(item);

        GameObjectActivate2(false, player, enemy, item);
    }

    #region �Ű����� ���
    // �Ϲ����� �Ű����� -> Call by Value / �� Ÿ��
    private void NormalParameter(int num)
    {
        num = 10;
        //num = 10;
        //number = num;
    }

    // ������ �Ű����� (Default �Ű�����) -> �Ű������� ���� �־�� ��
    private void DefaultParameter(int num = 3)
    {
        number = num;
    }

    // ���� ����� �Ű����� -> Call by Reference / ���� Ÿ�� / ������ ����
    private void ReferenceParameter(ref int num)
    {
        num = 20;
    }

    // ��ȯ�� ���� / ���ڸ� �ʱ�ȭ���� �ʾƵ� ��� ����
    private void OutParameter(out int num, out int num2)
    {
        num = 30;
        num2 = 50;
    }

    // Collection�� �Ű������� ���� ���
    private void ArrayParameter(int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    // params�� Ȱ���� �Ű����� -> ���ڸ� ���� �־ ��� ����
    private void ParamsParameter(params int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }
    private void GameObjectActivate() // �ϳ��� �� ���ų� �ݺ��� ����� ���� ����Ʈ�� ������ ��
    {
        // player.SetActive(false);
        // enemy.SetActive(false);
        // item.SetActive(false);

        foreach (var o in objs)
            o.SetActive(false);
    }

    private void GameObjectActivate2(bool isActive, params GameObject[] objs) // �Ķ����� �����ϰ� ����
    {
        foreach (var o in objs)
            o.SetActive(isActive);
    }
    #endregion

    #region Overloading
    // �����ε� : �Ű������� �ٸ��� �ؼ� �ٸ� ����� �����ϴ� ���
    private void OverloadingMethod() { Debug.Log("��� A"); }
    private void OverloadingMethod(int num) { Debug.Log("��� B"); }
    private void OverloadingMethod(float num) { Debug.Log("��� C"); }
    private void OverloadingMethod(bool isNum) { Debug.Log("��� D"); }
    private void OverloadingMethod(int num1, int num2) { Debug.Log("��� E"); }
    #endregion

}
