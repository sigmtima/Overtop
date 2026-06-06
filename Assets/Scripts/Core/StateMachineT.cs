using UnityEngine;

public abstract class StateMachine<T> : MonoBehaviour
{



    protected BaseState<T> CurrentState;
    public bool IsLocal;

    // Update is called once per frame
   protected virtual void Update()
    {
       // if (!IsLocal)
        //return;
        CurrentState?.Update();


    }
    public void ChangeState(BaseState<T> newState)
    {
        if (CurrentState != null)
        {
            CurrentState?.Exit();
           
        }
        CurrentState = newState;
        CurrentState?.Enter();

    }
    protected virtual void FixedUpdate()
    {
    
        CurrentState?.FixedUpdate();
    }
}


    
        
    

