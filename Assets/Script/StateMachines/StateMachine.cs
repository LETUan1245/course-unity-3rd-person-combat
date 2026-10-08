using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    // Update is called once per frame
    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
    void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
}
