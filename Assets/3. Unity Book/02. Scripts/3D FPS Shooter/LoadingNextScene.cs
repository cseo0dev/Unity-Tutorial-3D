using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingNextScene : MonoBehaviour
{

    public int sceneNumber = 2;
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;

    void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }

    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num);

        ao.allowSceneActivation = false; // 로드가 완료되어도 새로운 씬으로 이동 X

        while (!ao.isDone)
        {
            loadingBar.value = ao.progress;
            loadingText.text = $"{ao.progress * 100f}%";

            if (ao.progress >= 0.9f)
                ao.allowSceneActivation = true;

            yield return null;
        }
    }
}
