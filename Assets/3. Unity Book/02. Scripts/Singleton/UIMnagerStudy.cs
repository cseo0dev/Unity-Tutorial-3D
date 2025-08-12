using UnityEngine;

public class UIMnagerStudy : Singleton<UIMnagerStudy>
{
    protected override void Awake()
    {
        base.Awake();

        Debug.Log("추가할 기능");
    }
}
