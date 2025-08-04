using System;
using UnityEngine;

public class StudyFunc3 : MonoBehaviour
{
    public int hp = 100;

    public Func<int> GetHp;

    public Func<float, float> GetRemainHp;

    public Func<string> GetAction;

    void Start()
    {
        // ���� ü��
        GetHp = () => hp;

        // ������ ���� ������ ü��
        GetRemainHp = (dmg) => hp - dmg;

        GetAction = () =>
        {
            if (GetHp() > 50)
                return "����";
            else if (GetHp() > 20)
                return "����";
            else
                return "����";
        };
    }
}