using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    public GameManagerStudy gameManager;

    private Animator anim;

    public Action onStartSwing;
    public Action onEndSwing;

    private bool isSwing;

    void Start()
    {
        anim = GetComponent<Animator>();

        onStartSwing += SwingStart;
        onEndSwing += SwingEnd;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
                StartCoroutine(SwingRoutine(onStartSwing, onEndSwing));
        }
    }

    IEnumerator SwingRoutine(Action action1, Action action2)
    {
        isSwing = true;
        anim.SetTrigger("Swing");

        onStartSwing?.Invoke();

        // float animLength = anim.GetCurrentAnimatorClipInfo(0).Length;
        // float animLength = anim.GetCurrentAnimatorStateInfo(0).length; // ���� ���� ���� �ִϸ��̼��� ����(�ð�)
        yield return new WaitForSeconds(0.5f);

        onEndSwing?.Invoke();
        isSwing = false;
    }

    private void SwingStart()
    {
        Debug.Log("���� ����");
    }

    private void SwingEnd()
    {
        Debug.Log("���� ����");
    }
}
