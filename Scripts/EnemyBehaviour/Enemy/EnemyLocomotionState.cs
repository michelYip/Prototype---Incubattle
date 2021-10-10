using UnityEngine;

public class EnemyLocomotionState : MonoBehaviour, StateInterface
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
    }

    public void DoUpdate()
    {
        _enemyController.SetCheckAttackGameObject(true);
        if (_enemyController.GetTarget() != null)
        {
            //Vector2 direction = _enemyController.GetTarget().position - transform.position;
            Vector2 direction = _enemyController.GetDestination() - transform.position;
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
    /*public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, _enemyController.GetDestination());
    }*/

    #endregion

    #region Privates

    private EnemyController _enemyController;

    #endregion
}
