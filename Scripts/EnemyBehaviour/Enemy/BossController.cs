using UnityEngine;

public class BossController : EnemyController
{
	#region Exposed

	[SerializeField] private GameObject m_hitEffect;
	[SerializeField] private GameObject m_leftExplosionEffect;
	[SerializeField] private GameObject m_rightExplosionEffect;


	#endregion

	#region Unity API

	protected override void Awake()
	{
		base.Awake();

		_hitBoxSlam = transform.Find("HitBoxSlam").GetComponent<ColliderBehaviour>();
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("PlayerHitbox"))
		{
			CurrentHealth--;
			_damageTaken++;
			m_hitEffect.SetActive(false);
			m_hitEffect.SetActive(true);
			if (_damageTaken % 4 == 0)
				IsHurt = true;

			if (_damageTaken % 10 == 0)
				_doSpecialAttack = true;
		}
	}

	#endregion

	#region Main Methods

	protected void EnableHitBoxSlam()
	{
		_hitBoxSlam.EnableCollider();
	}

	protected void DisableHitBoxSlam()
	{
		_hitBoxSlam.DisableCollider();
	}

	public bool DoSpecialAttack { get => _doSpecialAttack; set => _doSpecialAttack = value; }

	public void PlayExplosionVFX()
	{
		m_leftExplosionEffect.SetActive(false);
		m_leftExplosionEffect.SetActive(true);
		m_rightExplosionEffect.SetActive(false);
		m_rightExplosionEffect.SetActive(true);
	}

	#endregion

	#region Privates

	private ColliderBehaviour _hitBoxSlam;
	private int _damageTaken = 0;
	private bool _doSpecialAttack = false;

	#endregion
}
