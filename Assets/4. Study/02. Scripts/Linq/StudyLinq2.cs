using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Linq 리스트 활용?
public class StudyLinq2 : MonoBehaviour
{
    [System.Serializable]
    public class Person
    {
        public string name;
        public int score;

        public Person(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public List<Person> persons = new List<Person>();

    public int cutline = 70;

    void Start()
    {
        persons.Add(new Person("John", 65));
        persons.Add(new Person("Sarah", 80));
        persons.Add(new Person("David", 95));
        persons.Add(new Person("Emily", 70));
        persons.Add(new Person("Michael", 50));

        CheckScore();
    }
    
    private void CheckScore()
    {
        #region Linq 사용 X
        // 과목이 나뉘거나 추가 가공을 하게 되면 번거로움 발생
        foreach (var person in persons)
        {
            if (person.score > cutline)
                Debug.Log($"{person.name} 통과");
            else
                Debug.Log($"{person.name} 탈락");
        }

        #endregion
        #region Linq 사용 O
        //var passPersons = from person in persons
        //                  where person.score >= cutline
        //                  select person;

        // 람다 사용
        var passPersons = persons.Where(p => p.score > cutline);
        var failPersons = persons.Except(passPersons);

        foreach (var p in passPersons)
            Debug.Log($"<color=green>{p.name}</color>");
        foreach (var p in failPersons)
            Debug.Log($"<color=red>{p.name}</color>");

        #endregion
    }
}
