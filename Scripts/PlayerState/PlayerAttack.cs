using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, StateInterface
{
    #region Exposed

    #endregion


    #region Unity APi 

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    #endregion 


    #region Main Methods

    public void DoInit()
    {
        _playerController.Attack();

        if(_playerController.Chrono < 0.5 && _playerController.IsJumping)
        {
            _playerController.Chrono += (0.5f - _playerController.Chrono) * 2;
        }
    }

    public void DoUpdate()
    {
        _playerController.SetVelocity(Vector2.zero);        
    }

    public void DoExit()
    {
        
    }

    #endregion

    #region Privates

    PlayerController _playerController;

    #endregion
}