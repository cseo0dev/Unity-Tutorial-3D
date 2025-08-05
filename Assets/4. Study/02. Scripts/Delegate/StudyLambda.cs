using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public MyDelegate myDelegate;

    public Button button;

    void Start()
    {
        // ��ư�� 1���� ����� ����ϴ� ���
        button.onClick.AddListener(ButtonEvent);
        // button.onClick.AddListener(OnLog("Hello")); // ��� X

        // �͸��Լ��� ���� ����� ����ϴ� ���
        button.onClick.AddListener(delegate
        {
            ButtonEvent();
            OnLog("Lambda");
        });

        // ���ٽ����� 1���� ����� ����ϴ� ���
        button.onClick.AddListener(() => OnLog("Hello"));

        // ���ٽ����� ���� ����� ����ϴ� ���
        button.onClick.AddListener(() =>
        {
            ButtonEvent();
            OnLog("Lambda");
        });
    }

    private void ButtonEvent()
    {
        Debug.Log("Button Event");
    }

    private void OnLog(string msg)
    {
        Debug.Log(msg);
    }
}