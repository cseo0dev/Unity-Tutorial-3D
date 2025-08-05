using UnityEngine;

public class StudySingleton : Singleton<StudySingleton>
{
    public static StudySingleton instance;

    public int number;

    void Start()
    {
        instance = this;
    }
}
