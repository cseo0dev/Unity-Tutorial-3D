using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World***";

    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    void Start()
    {
        /*
        Debug.Log(str1[0]); // H
        Debug.Log(str1[2]); // l

        Debug.Log(str2[0]); // Hello
        Debug.Log(str2[2]); // World

        Debug.Log(str1.Length); // ���ڿ��� ���� : 14
        Debug.Log(str1.Trim()); // �յ� ���� ���� : Hello World***
        Debug.Log(str1.Trim('*')); // �յ� ���� '*' ���� : Hello World

        Debug.Log(str1.Contains("H")); //  H ���翩�� Ȯ��
        Debug.Log(str1.Contains("h")); //  h ���翩�� Ȯ��
        Debug.Log(str1.Contains("Hello")); // Hello ���� ���� Ȯ�� 
        Debug.Log(str1.ToUpper()); // �빮�� ��ȯ
        Debug.Log(str1.ToLower()); // �ҹ��� ��ȯ

        Debug.Log(str1.Replace("World", "Unity")); // World�� Unity�� ��ȯ
        Debug.Log(str1);
        */

        string text = "Apple,Banana,Orange";

        string[] fruits = text.Split(','); // , �� �������� ���ڿ� �ڸ���

        foreach (var fruit in fruits)
            Debug.Log(fruit);
    }
}