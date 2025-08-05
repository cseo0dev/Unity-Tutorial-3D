using System.Linq;
using UnityEngine;

// 정렬 실습
public class StudyLinq3 : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        var result = from number in numbers
                     where number > 1
                     orderby number descending
                     select number;

        // 람다 사용
        var result2 = numbers.Where(n => n > 1).OrderByDescending(n => n);

        foreach (var number in result)
            Debug.Log(number);
    }
}
