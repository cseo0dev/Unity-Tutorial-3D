using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    private void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            queue.Enqueue(i); // 1 ~ 10 추가
        }

        int output = queue.Dequeue(); // 스택과 큐는 값을 반환 후 삭제하기 때문에 변수로 넣을 수 있음
        Debug.Log(output);

        Debug.Log(queue.Peek());

        Debug.Log(queue.Contains(5));

        queue.Clear(); // 모든 값 삭제

        Debug.Log(queue.Count);
    }
}
