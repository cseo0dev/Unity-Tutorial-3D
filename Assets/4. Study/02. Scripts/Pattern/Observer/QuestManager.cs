using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Pattern
{
    public class QuestManager : MonoBehaviour, IObserver
    {
        public ISubject subject;

        private bool isQuestClear1 = false;
        private bool isQuestClear2 = false;
        private bool isQuestClear3 = false;

        void OnEnable()
        {
            subject.AddObserver(this);
        }

        void OnDisable()
        {
            subject.RemoveObserver(this);
        }

        public void Notify(int score)
        {
            // ������ ���� ��
            if (score >= 100 && !isQuestClear1)
            {
                isQuestClear1 = true;
                Debug.Log("100�� �޼�!");
            }
            else if (score >= 500 && !isQuestClear1)
            {
                isQuestClear1 = true;
                Debug.Log("500�� �޼�!");
            }
            else if (score >= 1000 && !isQuestClear1)
            {
                isQuestClear1 = true;
                Debug.Log("1000�� �޼�!");
            }
        }
    }
}
