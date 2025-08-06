using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state;

    private IState idleState, moveState, attackState, jumpState;

    void Awake()
    {
        idleState = gameObject.AddComponent<IdleState>();
        moveState = gameObject.AddComponent<MoveState>();
        attackState = gameObject.AddComponent<AttackState>();
        jumpState = gameObject.AddComponent<JumpState>();

        state = idleState;
    }

    void Start()
    {
        state.StateEnter();
    }

    void OnDestroy()
    {
        state.StateExit();
    }

    void Update()
    {
        state?.StateUpdate();

        #region 기능 테스트
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(new IdleState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(new MoveState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(new AttackState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetState(new JumpState());
        }
        #endregion
    }

    public void SetState(IState newState)
    {
        if (state != newState)
        {
            state.StateExit(); // 상태 변경 전

            state = newState; // 상태 변경

            state.StateEnter(); // 상태 변경 후
        }
    }
}