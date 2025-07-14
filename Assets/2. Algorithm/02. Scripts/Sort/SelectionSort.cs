using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log("정렬 전 : " + string.Join(", ", array));

        Selection(array);
        Debug.Log("정렬 후 : " + string.Join (", ", array));
    }

    private void Selection(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++) // i 인덱스 선택
        {
            int minIdx = i;

            for (int j = i + 1; j < n; j++) // 다음 인덱스(j)와 값 비교
            {
                if (array[j] < array[minIdx])
                    minIdx = j;
            }

            int temp = array[i];
            array[i] = array[minIdx];
            array[minIdx] = temp;
        }
    }
}
