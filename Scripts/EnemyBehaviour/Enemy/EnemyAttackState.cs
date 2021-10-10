using UnityEngine;

public class EnemyAttackState : MonoBehaviour, StateInterface
{
    #region Exposed
    #endregion

    #region Unity API
    void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
    }
    #endregion

    #region Main Methods

    public void DoInit()
    {
        _enemyController.SetVelocity(Vector2.zero);
        _enemyController.SetTrigger("AttackTrigger");
    }

    public void DoUpdate()
    {
        _enemyController.SetVelocity(Vector2.zero);
        if (!_enemyController.GetAttack() && _enemyController.CanAttack())
        {
            _enemyController.SetTrigger("AttackTrigger");
        }
    }

    public void DoExit()
    {

    }

    #endregion

    #region Privates

    private EnemyController _enemyController;

    #endregion
}