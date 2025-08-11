using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    // Invoke 이벤트를 사용하는 방법 2 - Event 연결 x
    public class PlayerController3 : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        private PlayerInput playerInput; // Input Action Asset말고 컴포넌트 통해서 처리 가능

        private InputAction moveAction;
        private InputAction jumpAction;

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            moveAction = playerInput.actions.FindAction("Player/Move");
            jumpAction = playerInput.actions.FindAction("Player/Jump");

            cc = GetComponent<CharacterController>();
        }

        // context에 등록? -> 인스펙터 창에서 Evnet 연결 안해도 됨
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

        // CallbackContext는 키 변경이 있는 경우에만 반환해줌 -> 조건문 걸어서 널 값 체크 안해도 됨
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