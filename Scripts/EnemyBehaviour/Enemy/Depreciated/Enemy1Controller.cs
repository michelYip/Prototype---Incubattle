using UnityEngine;

public class Enemy1Controller : AbstractController
{
	#region Exposed

	[SerializeField] private float m_moveSpeed = 3f;

	#endregion

	#region Unity API

	protected override void Awake()
	{
		base.Awake();

		_hitBox = GetComponentInChildren<ColliderBehaviour>();
		_searchObject = GetComponentInChildren<SearchObjects>();
		_checkAttack = GetComponentInChildren<CheckAttack>();
	}

	#endregion

	#region Main Methods

	private void EnableHitBox()
	{
		_hitBox.EnableCollider();
	}

	private void DisableHitBox()
	{
		_hitBox.DisableCollider();
	}

	public Transform GetTarget()
	{
		return _searchObject.GetTarget();
	}

	public float GetMoveSpeed()
	{
		return m_moveSpeed;
	}

	public bool CanAttack()
	{
		return _checkAttack.CanAttack();
	}

	#endregion

	#region Privates

	private ColliderBehaviour _hitBox;
	private SearchObjects _searchObject;
	private CheckAttack   _checkAttack;

	#endregion
}
