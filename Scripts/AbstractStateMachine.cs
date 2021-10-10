using UnityEngine;
public enum State
{
	ATTACK,
	DIE,
	DIVE,
	HURT,
	JUMP,
	LOCOMOTION,
	TAUNT,
	THROW,
	SPECIAL,
	PICKUP
}

public abstract class AbstractStateMachine : MonoBehaviour
{
	#region Exposed	
	#endregion

	#region Unity API

	protected virtual void Awake()
	{
		_currentState = State.LOCOMOTION;
	}

	private void Update()
	{
		OnStateUpdate();
	}

	#endregion

	#region Main Methods

	protected abstract void OnStateEnter();

	protected abstract void OnStateUpdate();

	protected abstract void OnStateExit();

	protected void TransitionToState(State newState)
	{
		OnStateExit();
		_currentState = newState;
		OnStateEnter();
	}

	#endregion

	#region Privates

	protected State _currentState; 

	#endregion
}
