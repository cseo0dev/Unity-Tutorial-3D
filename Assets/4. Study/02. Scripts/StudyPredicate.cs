using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    public Predicate<int> myPredicate;

    public int level = 10;

    void Start()
    {
        myPredicate = n => n <= 10;
        string msg = myPredicate(level) ? "�ʺ��� ����� ���� ����" : "�ʺ��� ����� ���� �Ұ���";
        Debug.Log(msg);
    }
}