using System;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static Action emergencyStopButton;

    void Start()
    {
        emergencyStopButton += StopMessage;
    }

    private void StopMessage()
    {
        Debug.Log("��� ���� ����");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            emergencyStopButton?.Invoke();
        }
    }
}