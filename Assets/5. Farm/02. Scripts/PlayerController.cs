using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;

        private CharacterController cc;
        private Vector3 moveInput;

        private bool isRun;

        private float currentSpeed;
        private float walkSpeed = 2f;
        private float runSpeed = 5f;
        private float turnSpeed = 10f;

        void Start()
        {
            anim = GetComponent<Animator>();
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            cc.Move(moveInput * currentSpeed * Time.deltaTime);
            Turn();
            SetAnimation();
        }

        void OnMove(InputValue value)
        {
            var move = value.Get<Vector2>();
            moveInput = new Vector3(move.x, 0, move.y);
        }

        private void Turn()
        {
            if (moveInput != Vector3.zero)
            {
                // LookAt = Transform ����� Ư�� Vector3�� �ٶ󺸴� ���
                // LookRotation = Quaternion ����� Ư�� Vector3�� �ٶ󺸴� ���
                Quaternion targetRot = Quaternion.LookRotation(moveInput);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime); // Slerp(���� ȸ��, ��ǥ ȸ��, ����(�ӵ�))
            }
        }

        private void OnRun(InputValue value)
        {
            isRun = value.isPressed;
        }

        private void SetAnimation()
        {
            float targetValue = 0f;
            if (moveInput != Vector3.zero)
            {
                targetValue = isRun ? 1f : 0.5f;
                currentSpeed = isRun ? runSpeed : walkSpeed;
            }

            float animValue = anim.GetFloat("Move");
            animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);

            anim.SetFloat("Move", animValue);
        }
    }
}
