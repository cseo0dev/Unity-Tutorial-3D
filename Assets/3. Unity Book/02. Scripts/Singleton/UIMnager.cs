using UnityEngine;

public class UIMnager : Singleton<UIMnager>
{
    protected override void Awake()
    {
        base.Awake();

        Debug.Log("추가할 기능");
    }
}
