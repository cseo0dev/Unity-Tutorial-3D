using UnityEngine;

namespace Pettern
{
    public class ScoreController : MonoBehaviour
    {
        public int score = 0;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                score++;
                StudyEventBus.ScoreChanged(score);
            }
        }
    }
}

