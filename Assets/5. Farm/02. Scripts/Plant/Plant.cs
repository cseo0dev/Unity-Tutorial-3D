using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Plant : MonoBehaviour
{
    private enum PlantState {  Level1, Level2, Level3 }
    private PlantState plantState;

    private DateTime startTime, growhTime, harvestTime;

    private bool isHarvest = false;

    void Awake()
    {
        startTime = DateTime.Now; // 현재 시간 활용
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

    void Update()
    {
        
    }

    private void SetState(PlantState newState)
    {
        if (plantState != newState || plantState == PlantState.Level1)
        {
            plantState = newState;

            for (int i = 0; i < 3; i++) // 식물 프리팹 중 흙 빼고 모두 끄기
                transform.GetChild(i).gameObject.SetActive(false);

            transform.GetChild((int)plantState).gameObject.SetActive(true); // 특정 레벨 프리팹만 활성화
        }
    }
}
