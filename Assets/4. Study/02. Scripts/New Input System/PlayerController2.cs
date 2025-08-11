using UnityEngine;
using UnityEngine.InputSystem;


namespace NewInputSystem
{
    // Invoke 이벤트를 사용하는 방법 1
    public class PlayerController2 : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        // Event 연결 필요
        public void Move(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
            if (moveInput != Vector2.zero)
            {
                Debug.Log("Move : " + moveInput);
                var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

                cc.Move(dir * speed * Time.deltaTime);
            }
        }

        public void Jump(InputAction.CallbackContext context)
        {
            Debug.Log("Jump");
            // 점프 기능 실행
        }
    }
}