using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    void Start()
    {
        StudySingleton.instance.number = 10;
    }
}