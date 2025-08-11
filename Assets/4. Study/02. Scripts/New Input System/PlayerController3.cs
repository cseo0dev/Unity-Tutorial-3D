using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    // Invoke �̺�Ʈ�� ����ϴ� ��� 2 - Event ���� x
    public class PlayerController3 : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        private PlayerInput playerInput; // Input Action Asset���� ������Ʈ ���ؼ� ó�� ����

        private InputAction moveAction;
        private InputAction jumpAction;

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            moveAction = playerInput.actions.FindAction("Player/Move");
            jumpAction = playerInput.actions.FindAction("Player/Jump");

            cc = GetComponent<CharacterController>();
        }

        // context�� ���? -> �ν����� â���� Evnet ���� ���ص� ��
        void OnEnable()
        {
            moveAction.Enable();
            moveAction.performed += MoveStart;
            moveAction.canceled += MoveCancel;

            jumpAction.Enable();
            jumpAction.performed += Jump;
        }

        void OnDisable()
        {
            moveAction.Disable();
            moveAction.performed -= MoveStart;
            moveAction.canceled -= MoveCancel;

            jumpAction.Disable();
            jumpAction.performed -= Jump;
        }

        void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            Debug.Log(dir);

            cc.Move(dir * speed * Time.deltaTime);
        }

        // CallbackContext�� Ű ������ �ִ� ��쿡�� ��ȯ���� -> ���ǹ� �ɾ �� �� üũ ���ص� ��
        public void MoveStart(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void MoveCancel(InputAction.CallbackContext context)
        {
            moveInput = Vector2.zero;
        }

        public void Jump(InputAction.CallbackContext context)
        {
            Debug.Log("Jump");
        }
    }
}