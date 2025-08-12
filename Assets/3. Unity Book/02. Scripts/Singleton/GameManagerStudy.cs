using UnityEngine;

public class GameManagerStudy : Singleton<GameManagerStudy>
{
    protected override void Awake()
    {
        base.Awake();

        Debug.Log("추가할 기능");
    }
}
