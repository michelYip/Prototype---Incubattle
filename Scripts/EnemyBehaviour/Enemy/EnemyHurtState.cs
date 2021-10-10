using UnityEngine;

public class EnemyHurtState : MonoBehaviour, StateInterface
{
	#region Exposed

	[SerializeField] private float m_hurtDuration = 0.5f;
	[SerializeField] private GameObject m_hitEffect;

	#endregion

	#region Unity API
	void Awake()
	{
		_enemyController = GetComponent<EnemyController>();
		_hurtTimer = Time.time;
		_hasExitHurt = false;

		_hurtSFX = transform.Find("HurtSFX").GetComponent<AudioSource>();
	}
	#endregion

	#region Main Methods

	public void DoInit()
	{
		_enemyController.SetVelocity(Vector2.zero);
		_enemyController.SetTrigger("HitTrigger");
		_hurtTimer = Time.time + m_hurtDuration;
		_hasExitHurt = false;
		_enemyController.IsHurt = false;

		_enemyController.CurrentHealth--;
		//Debug.Log(_hurtTimer);
		m_hitEffect.SetActive(false);
		m_hitEffect.SetActive(true);

		_hurtSFX.Play();
	}

	public void DoUpdate()
	{
		if (Time.time > _hurtTimer)
		{
			_hasExitHurt = true;
			_enemyController.IsHurt = false;
		}
	}

	public void DoExit()
	{
	}

	public bool HasExitHurt { get => _hasExitHurt; set => _hasExitHurt = value; }

	#endregion

	#region Privates

	private EnemyController _enemyController;

	private float _hurtTimer;
	private bool _hasExitHurt;
	private AudioSource _hurtSFX;

	#endregion
}