using System.Linq;
using UnityEngine;

// Linq 기본 사용법
public class StudyLinq : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        // IEnumerable 표현 방식
        var result = from number in numbers
                     where number > 3
                     select number;

        // Lambda 표현 방식
        var result2 = numbers.Where (n => n > 3);
        var result3 = numbers.Select(n => n * n);

        foreach (var n in result)
            Debug.Log(n);
    }
}
