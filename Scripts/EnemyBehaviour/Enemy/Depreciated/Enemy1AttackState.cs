using UnityEngine;

[RequireComponent(typeof(Enemy1Controller))]
public class Enemy1AttackState : MonoBehaviour, StateInterface
{
    #region Exposed
    #endregion

    #region Unity API
    void Awake()
    {
        _enemyController = GetComponent<Enemy1Controller>();
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

    private Enemy1Controller _enemyController;

    #endregion
}