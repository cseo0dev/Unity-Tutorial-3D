using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    void Start()
    {
        ButtonManager.emergencyStopButton += TimerView;
    }

    private void TimerView()
    {

    }
}