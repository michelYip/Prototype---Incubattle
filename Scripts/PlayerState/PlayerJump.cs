using UnityEngine;

public class PlayerJump : MonoBehaviour, StateInterface
{
    #region Exposed
    #endregion

    #region Unity API

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    #endregion

    #region Main Methods

    public void DoInit()
    {
        _playerController.IsJumping = true;
    }

    public void DoUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }

        _playerController.Jump();
        _playerController.Chrono += Time.deltaTime;

        if (_playerController.IsDead)
        { _playerController.SetVelocity(Vector3.zero); }
    }

    public void DoExit()
    {
        
    }

    #endregion

    #region Privates

    PlayerController _playerController;

    #endregion
}