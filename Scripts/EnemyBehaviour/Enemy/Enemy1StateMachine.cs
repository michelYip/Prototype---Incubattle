using UnityEngine;

[RequireComponent(typeof(EnemyLocomotionState))]
[RequireComponent(typeof(EnemyAttackState))]
[RequireComponent(typeof(EnemyHurtState))]
[RequireComponent(typeof(EnemyDieState))]
public class Enemy1StateMachine : AbstractStateMachine
{
	#region Exposed
	#endregion

	#region Unity API

	protected override void Awake()
	{

		base.Awake();

		_enemyController = GetComponent<EnemyController>();

		_enemyLocomotion = GetComponent<EnemyLocomotionState>();
		_enemyAttack = GetComponent<EnemyAttackState>();
		_enemyHurt = GetComponent<EnemyHurtState>();
		_enemyDie = GetComponent<EnemyDieState>();

	}

	#endregion

	#region Main Methods

	protected override void  OnStateEnter()
	{
		switch (_currentState)
		{
			case State.LOCOMOTION:
				_enemyLocomotion.DoInit();
				break;

			case State.ATTACK:
				_enemyAttack.DoInit();
				break;

			case State.HURT:
				_enemyHurt.DoInit();
				break;

			case State.DIE:
				_enemyDie.DoInit();
				break;

			default:
				Debug.Log(_currentState.ToString() + " is not implemented in " + gameObject.GetType().Name);
				break;
		}
	}

	protected override void OnStateUpdate()
	{
		switch (_currentState)
		{
			case State.LOCOMOTION:
				_enemyLocomotion.DoUpdate();
				if (_enemyController.CanAttack() && _allowAttack == false)
				{
					_allowAttack = true;
					_attackTimer = Time.time + _timeBeforeAttack;
				}
				if (_allowAttack == true && Time.time > _attackTimer)
				{
					TransitionToState(State.ATTACK);
					_allowAttack = false;
				}

				if (_enemyController.IsHurt)
					TransitionToState(State.HURT);
				break;

			case State.ATTACK:
				_enemyAttack.DoUpdate();
				if (!_enemyController.CanAttack() && !_enemyController.GetAttack())
					TransitionToState(State.LOCOMOTION);
				break;

			case State.HURT:
				_enemyHurt.DoUpdate();
				if (_enemyHurt.HasExitHurt)
					TransitionToState(State.LOCOMOTION);

				else if (_enemyController.IsHurt)
					TransitionToState(State.HURT);
				
				if (_enemyController.CurrentHealth <= 0)
					TransitionToState(State.DIE);
				break;

			case State.DIE:
				_enemyDie.DoUpdate();
				break;

			default:
				Debug.Log(_currentState.ToString() + " state is not implemented in " + gameObject.GetType().Name);
				break;
		}
	}

	protected override void OnStateExit()
	{
		switch (_currentState)
		{
			case State.ATTACK:
				_enemyAttack.DoExit();
				break;

			case State.DIE:
				break;

			case State.HURT:
				_enemyHurt.DoExit();
				break;

			case State.LOCOMOTION:
				_enemyLocomotion.DoExit();
				break;

			default:
				Debug.Log(_currentState.ToString() + " state is not implemented in " + gameObject.GetType().Name);
				break;
		}
	}

	#endregion

	#region Privates

	private EnemyController _enemyController;

	private EnemyLocomotionState _enemyLocomotion;
	private EnemyAttackState _enemyAttack;
	private EnemyHurtState _enemyHurt;
	private EnemyDieState _enemyDie;

	private bool _allowAttack;
	private float _attackTimer;
	private float _timeBeforeAttack = 0.75f;

	#endregion
}
