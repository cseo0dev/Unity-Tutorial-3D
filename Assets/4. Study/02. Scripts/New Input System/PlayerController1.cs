using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController1 : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        public InputActionAsset inputActionAsset;

        private InputAction moveAction;
        private InputAction jumpAction;
        private InputAction interactionAction;
        private InputAction attackAction;

        void Start()
        {
            // Input Action Asset�� ��ũ��Ʈ���� ���
            moveAction = InputSystem.actions.FindAction("Move");
            jumpAction = InputSystem.actions.FindAction("Jump");
            interactionAction = InputSystem.actions.FindAction("Interaction");
            attackAction = InputSystem.actions.FindAction("Attack");

            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            moveInput = moveAction.ReadValue<Vector2>();

            if (moveInput != Vector2.zero)
            {
                Debug.Log("Move : " + moveAction.ReadValue<Vector2>());
                var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

                cc.Move(dir * speed * Time.deltaTime);
            }

            if (jumpAction.IsPressed()) // IsPressed() : ������ ���� | WasPressedThisFrame() : �ѹ� ����
                Debug.Log("Jump");

            if (interactionAction.IsPressed())
                Debug.Log("Interaction");

            if (attackAction.IsPressed())
                Debug.Log("Attack");
        }
    }
}