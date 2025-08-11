using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    // Input Value(Send Messages)�� ����ϴ� ���
    public class PlayerController4 : MonoBehaviour
    {
        private CharacterController cc;

        public float speed = 5f;

        private Vector2 moveInput;

        void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y);
            cc.Move(dir * speed * Time.deltaTime);
        }

        private void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        private void OnJump(InputValue value)
        {
            bool isJump = value.isPressed;
            Debug.Log(isJump);
        }

        // True, False�� Ȱ���ϱ� ���� Input Action Type�� Value�� ��� -> �� ������ ��ȣ�ۿ� ����
        private void OnInteraction(InputValue value)
        {
            Debug.Log(value.isPressed);
        }

        private void OnAttack(InputValue value)
        {
            Debug.Log("OnAttack");
        }
    }
}