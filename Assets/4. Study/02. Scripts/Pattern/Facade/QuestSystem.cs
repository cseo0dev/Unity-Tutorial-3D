using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public void StartQuest(string questName)
    {
        Debug.Log($"{questName} ȹ��");
    }

    public void HasQuest(string questName)
    {
        Debug.Log($"{questName} ����");
    }

    public void CompleteQuest(string questName)
    {
        Debug.Log($"{questName} ����");
    }
}
