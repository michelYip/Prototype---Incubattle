using UnityEngine;

[RequireComponent(typeof(Enemy1Controller))]
public class Enemy1LocomotionState : MonoBehaviour, StateInterface
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

	}

    public void DoUpdate()
	{
        if (_enemyController.GetTarget() != null)
		{
            Vector2 direction = _enemyController.GetTarget().position - transform.position;
            direction.Normalize();

            _enemyController.SetVelocity(direction * _enemyController.GetMoveSpeed());
            _enemyController.SetFloat("MoveSpeed", 1f);

            if (direction.x < 0)
			{
                transform.localScale = new Vector3(-1, 1, 1);
			}
            else
			{
                transform.localScale = new Vector3(1, 1, 1);
			}
        }
        else
		{
            _enemyController.SetVelocity(Vector2.zero);
            _enemyController.SetFloat("MoveSpeed", 0f);
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
