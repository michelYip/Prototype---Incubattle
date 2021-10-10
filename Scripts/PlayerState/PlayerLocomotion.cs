using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour, StateInterface
{
    #region Unity API

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();        
    }

    #endregion

    #region Main Methods

    public void DoInit()
    {
        
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

        _playerController.Move();

        if(_playerController.IsDead)
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