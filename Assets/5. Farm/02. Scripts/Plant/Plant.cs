using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private enum PlantState {  Level1, Level2, Level3 }
    private PlantState plantState;

    private DateTime startTime, growhTime, harvestTime;

    public int plantIndex;
    public bool isHarvest = false;

    void Awake()
    {
        startTime = DateTime.Now; // ���� �ð� Ȱ��
        growhTime = startTime.AddSeconds(5);
        harvestTime = startTime.AddSeconds(10);
    }

    IEnumerator Start()
    {
        SetState(PlantState.Level1);

        while (plantState != PlantState.Level3)
        {
            if (DateTime.Now >= harvestTime)
            {
                SetState(PlantState.Level3);
                isHarvest = true;
            }
            else if (DateTime.Now >= growhTime)
                SetState(PlantState.Level2);

            yield return new WaitForSeconds(1f);
        }
    }

    private void SetState(PlantState newState)
    {
        if (plantState != newState || plantState == PlantState.Level1)
        {
            plantState = newState;

            for (int i = 0; i < 3; i++) // �Ĺ� ������ �� �� ���� ��� ����
                transform.GetChild(i).gameObject.SetActive(false);

            transform.GetChild((int)plantState).gameObject.SetActive(true); // Ư�� ���� �����ո� Ȱ��ȭ
        }
    }

    private void SetGrowth(WeatherType weatherType)
    {
        switch (weatherType)
        {
            case WeatherType.Sun:
                // ���� �ִ�
                break;
            case WeatherType.Rain:
                // ���� �߰�
                break;
            case WeatherType.Snow:
                // ���� �ּ�
                break;
        }
    }
}
