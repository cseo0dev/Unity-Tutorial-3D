using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public string URL;

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL); // ��û ����
        yield return www.SendWebRequest();

        WWWForm form = new WWWForm();
        form.AddField("value", "123");

        UnityWebRequest www2 = UnityWebRequest.Post(URL, form); // ��û ����
        yield return www2.SendWebRequest();

        string data = www.downloadHandler.text; // ��û ���� �� : Get
                                                // string data2 = www2.downloadHandler.text; // ��û ���� �� : Post

        Debug.Log(data);
        // Debug.Log(data2);
    }
}