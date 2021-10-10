using UnityEngine;

public class EnemyController : AbstractController
{
	#region Exposed

	[SerializeField] private EnemyStatsScriptable _defaultStats;

	#endregion

	#region Unity API

	protected override void Awake()
	{
		base.Awake();

		//_hitBox = GetComponentInChildren<ColliderBehaviour>();
		_hitBox = transform.Find("HitBox").GetComponent<ColliderBehaviour>();
		_searchObject = GetComponentInChildren<SearchObjects>();
		_checkAttackGameObject = transform.Find("AttackDetectionBox").gameObject;
		_checkAttack = _checkAttackGameObject.GetComponent<CheckAttack>();

		_currentHealth = _defaultStats.HealthPoint;
		_moveSpeed = _defaultStats.MoveSpeed;
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("PlayerHitbox"))
		{
			//Debug.Log(transform.tag);
			IsHurt = true;
		}
	}

	#endregion

	#region Main Methods

	protected void EnableHitBox()
	{
		SetCheckAttackGameObject(true);
		_hitBox.EnableCollider();
	}

	protected void DisableHitBox()
	{
		SetCheckAttackGameObject(false);
		_hitBox.DisableCollider();
	}

	public void SetCheckAttackGameObject(bool value)
	{
		_checkAttackGameObject.SetActive(value);
	}

	public Transform GetTarget()
	{
		return _searchObject.GetTarget();
	}

	public Vector3 GetDestination()
	{
		return _searchObject.GetDestination();
	}

	public float GetMoveSpeed()
	{
		return _moveSpeed;
	}

	public bool CanAttack()
	{
		return _checkAttack.CanAttack();
	}

	public float GetDetectionDistance()
	{
		return _searchObject.GetDetectionDistance();
	}

	public float GetTargetDistance()
	{
		return _searchObject.GetTargetDistance();
	}

	public bool IsHurt { get => _isHurt; set => _isHurt = value; }
	public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

	#endregion

	#region Privates

	protected ColliderBehaviour _hitBox;
	protected SearchObjects _searchObject;
	protected CheckAttack _checkAttack;
	protected GameObject _checkAttackGameObject;

	protected int _currentHealth;
	protected float _moveSpeed;
	protected bool _isHurt;

	#endregion
}
