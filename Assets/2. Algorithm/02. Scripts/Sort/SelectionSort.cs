using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log("���� �� : " + string.Join(", ", array));

        Selection(array);
        Debug.Log("���� �� : " + string.Join (", ", array));
    }

    private void Selection(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++) // i �ε��� ����
        {
            int minIdx = i;

            for (int j = i + 1; j < n; j++) // ���� �ε���(j)�� �� ��
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
