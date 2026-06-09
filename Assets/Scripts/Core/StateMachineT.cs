using UnityEngine;

public abstract class StateMachine<T> : MonoBehaviour
{
    public bool IsLocal;

    protected BaseState<T> CurrentState;

    // Update is called once per frame
    protected virtual void Update()
    {
        // if (!IsLocal)
        //return;
        CurrentState?.Update();
    }

    protected virtual void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }

    public void ChangeState(BaseState<T> newState)
    {
        if (CurrentState != null) CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }
}