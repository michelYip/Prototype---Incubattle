using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class AbstractController : MonoBehaviour
{
	#region Exposed
	#endregion

	#region Unity API

	protected virtual void Awake()
	{
		_animator = GetComponent<Animator>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_velocity = Vector2.zero;
		_graphics = GameObject.Find("Graphics");

		Debug.Log(gameObject.name);
	}

	private void FixedUpdate()
	{
		_rigidbody2D.velocity = _velocity;
	}

	#endregion

	#region Main Methods

	public void SetVelocity(Vector2 velocity)
	{
		_velocity = velocity;
	}

	public Vector2 GetVelocity()
	{
		return _velocity;
	}	

	public void SetInteger(string param, int value)
	{
		_animator.SetInteger(param, value);
	}

	public void SetFloat(string param, float value)
	{
		_animator.SetFloat(param, value);
	}

	public void SetBool(string param, bool value)
	{
		_animator.SetBool(param, value);
	}

	public void SetTrigger(string param)
	{
		_animator.SetTrigger(param);
	}

    public void ResetTrigger(string param)
    {
		_animator.ResetTrigger(param);
    }

    public void SetAttackTrue()
	{
		_isAttacking = true;
	}

	public void SetAttackFalse()
	{
		_isAttacking = false;
	}

	public bool GetAttack()
	{
		return _isAttacking;
	}
	#endregion

	#region Privates

	protected Animator _animator;
	protected Rigidbody2D _rigidbody2D;
	protected Vector2 _velocity;
	protected GameObject _graphics;

	protected bool _isAttacking;

	#endregion
}
