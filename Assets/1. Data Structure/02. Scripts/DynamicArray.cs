using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>();

    void Start()
    {
        for (int i = 1; i <= 10; i++) // 1 ~ 10���� ���� list1�� �߰�
            list1.Add(i); // �ڿ� i�� �߰�

        // list1.Insert(5, 100); // �ε��� 5���� 100�� ����
        // list1.Remove(5); // �� 5�� ����
        // list1.RemoveAt(5); // �ε��� 5���� �ִ� ���� ����
        // list1.RemoveRange(1, 3); // �ε��� 1������ 3������ ����
        // list1.Clear(); // ������ ��� ����
        // list1.RemoveAll(x => x > 5); // ���� List �ȿ��� x > 5 ���� ��� ����
        // list1.Sort(); // �������� ����
        // string str = String.Empty; // ""
        // foreach (var x in list1)
        // {
        //     str += x.ToString() + " / ";
        // }
        //
        // Debug.Log(str);

        if (list1.Contains(10)) // List���� 10�̶�� ���� ������ true
            Debug.Log("�� 10�� ���� O");
        else
            Debug.Log("�� 10�� ���� X");
    }
}