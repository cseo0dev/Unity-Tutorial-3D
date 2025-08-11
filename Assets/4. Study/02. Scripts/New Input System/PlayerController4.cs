using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    // Input Value(Send Messages)를 사용하는 방법
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

        // True, False를 활용하기 위해 Input Action Type을 Value로 사용 -> 꾹 누르는 상호작용 가능
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