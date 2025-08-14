using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;

    [SerializeField] private Animator[] characterAnims;

    [SerializeField] private Button[] turnButtons; // 0 : Left, 1 : Right
    [SerializeField] private Button selectButton;

    private int currentIndex;

    private bool isTurn;

    void Start()
    {
        turnButtons[0].onClick.AddListener(() => Turn(true));
        turnButtons[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(Select);
    }
    private void Turn(bool isLeft)
    {
        if (!isTurn)
        {
            isTurn = true;

            int value = isLeft ? -1 : 1;
            currentIndex += value;

            // ĳ���Ͱ� 4���̱� ������ 0 ~ 3 ������ ����
            if (currentIndex < 0) currentIndex = 3;
            else if (currentIndex > 3) currentIndex = 0;

            float turnValue = value * 90;
            var targetRot = centerPivot.rotation * Quaternion.Euler(0, turnValue, 0);

            StartCoroutine(TurnRoutine(targetRot));
        }
    }

    IEnumerator TurnRoutine(Quaternion targetRot)
    {
        while (true)
        {
            yield return null; // while true�� ���� ������ �ȿ� yield return �ʿ� (���� ���� ����)

            // �ε巴�� ȸ��
            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 5f * Time.deltaTime);

            var angle = Quaternion.Angle(centerPivot.rotation, targetRot);
            if (angle <= 0.1f)
            {
                isTurn = false;
                Debug.Log("Completed Turn");
                centerPivot.rotation = targetRot;

                yield break;
            }
        }
    }

    private void Select()
    {
        Debug.Log($"���� ������ ĳ���ʹ� {currentIndex}��° ĳ�����Դϴ�.");
        StartCoroutine(SelectRoutine());
    }

    IEnumerator SelectRoutine()
    {
        characterAnims[currentIndex].SetTrigger("Select");

        yield return new WaitForSeconds(3f);

        Fade.onFadeAction?.Invoke(3f, Color.white, true, null);

        yield return new WaitForSeconds(3.5f);
    }
}
