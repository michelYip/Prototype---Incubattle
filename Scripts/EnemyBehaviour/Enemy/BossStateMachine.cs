using UnityEngine;

[RequireComponent(typeof(EnemyLocomotionState))]
[RequireComponent(typeof(EnemyAttackState))]
[RequireComponent(typeof(BossHurtState))]
[RequireComponent(typeof(EnemyDieState))]
[RequireComponent(typeof(BossSpecialState))]
public class BossStateMachine : AbstractStateMachine
{
    #region Exposed
    #endregion

    #region Unity API
    protected override void Awake()
    {
        base.Awake();

		_bossController = GetComponent<BossController>();

		_enemyLocomotion = GetComponent<EnemyLocomotionState>();
		_enemyAttack = GetComponent<EnemyAttackState>();
		_enemyHurt = GetComponent<BossHurtState>();
		_enemyDie = GetComponent<EnemyDieState>();
		_bossSpecial = GetComponent<BossSpecialState>();
	}
	#endregion

	#region Main Methods

	protected override void OnStateEnter()
	{
		switch (_currentState)
		{
			case State.ATTACK:
				_enemyAttack.DoInit();
				break;
			case State.DIE:
				_enemyDie.DoInit();
				break;
			case State.HURT:
				_enemyHurt.DoInit();
				break;
			case State.LOCOMOTION:
				_enemyLocomotion.DoInit();
				break;
			case State.TAUNT:
				break;
			case State.SPECIAL:
				_bossSpecial.DoInit();
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
			case State.ATTACK:
				_enemyAttack.DoUpdate();

				if (_bossController.DoSpecialAttack)
				{
					_bossController.DoSpecialAttack = false;
					TransitionToState(State.SPECIAL);
				}

				if (!_bossController.CanAttack() && !_bossController.GetAttack())
					TransitionToState(State.LOCOMOTION);

				if (_bossController.CurrentHealth <= 0)
					TransitionToState(State.DIE);

				break;

			case State.DIE:
				_enemyDie.DoUpdate();
				break;

			case State.HURT:
				_enemyHurt.DoUpdate();

				if (_bossController.DoSpecialAttack)
				{
					_bossController.DoSpecialAttack = false;
					TransitionToState(State.SPECIAL);
				}

				if (_enemyHurt.HasExitHurt)
					TransitionToState(State.LOCOMOTION);

				else if (_bossController.IsHurt)
					TransitionToState(State.HURT);

				if (_bossController.CurrentHealth <= 0)
					TransitionToState(State.DIE);
				break;

			case State.LOCOMOTION:
				_enemyLocomotion.DoUpdate();

				if (_bossController.DoSpecialAttack)
				{
					_bossController.DoSpecialAttack = false;
					TransitionToState(State.SPECIAL);
				}

				if (_bossController.CanAttack() && _allowAttack == false)
				{
					_allowAttack = true;
					_attackTimer = Time.time + _timeBeforeAttack;
				}
				if (_allowAttack == true && Time.time > _attackTimer)
				{
					TransitionToState(State.ATTACK);
					_allowAttack = false;
				}

				if (_bossController.IsHurt)
					TransitionToState(State.HURT);
				if (_bossController.CurrentHealth <= 0)
					TransitionToState(State.DIE);
				break;

			case State.TAUNT:
				break;
			
			case State.SPECIAL:
				_bossSpecial.DoUpdate();
				if (_bossSpecial.SpecialDone)
				{
					TransitionToState(State.LOCOMOTION);
				}
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

			case State.TAUNT:
				break;

			case State.SPECIAL:
				_bossSpecial.DoExit();
				break;

			default:
				break;
		}
	}

	#endregion

	#region Privates

	private BossController _bossController;

	private EnemyLocomotionState _enemyLocomotion;
	private EnemyAttackState _enemyAttack;
	private BossHurtState _enemyHurt;
	private EnemyDieState _enemyDie;
	private BossSpecialState _bossSpecial;

	private bool _allowAttack;
	private float _attackTimer;
	private float _timeBeforeAttack = 0.75f;

	#endregion
}
