using UnityEngine;

public class EnemyThrowShockwaveState : MonoBehaviour, StateInterface
{
    #region Exposed

    [SerializeField] private GameObject m_shockwavePrefabs;
    [SerializeField] private float m_skillCooldown = 3f;
    [SerializeField] private float m_canMoveCooldown = 0.2f;

    #endregion

    #region Unity API
    void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        _cooldownTimer = Time.time;
    }
    #endregion

    #region Main Methods

    public void DoInit()
    {
        _enemyController.SetVelocity(Vector2.zero);

        _enemyController.SetTrigger("ThrowTrigger");
        Transform shockwaveTransform = Instantiate(m_shockwavePrefabs, transform.position, m_shockwavePrefabs.transform.rotation).transform;

        Vector2 direction = (_enemyController.GetTarget().position - transform.position).normalized;
        ShockwaveController shockwave = shockwaveTransform.GetComponent<ShockwaveController>();
        shockwave.SetDirection(direction);

        _cooldownTimer = Time.time + m_skillCooldown;
        _canMoveTimer = Time.time + m_canMoveCooldown;
    }

    public void DoUpdate()
    {
    }

    public void DoExit()
    {
    }

    public bool CanThrowShockwave()
	{
        return Time.time > _cooldownTimer;
	}

    public bool CanMove()
	{
        return Time.time > _canMoveTimer;
	}

    #endregion

    #region Privates

    private EnemyController _enemyController;

    private float _cooldownTimer;
    private float _canMoveTimer;

    #endregion
}