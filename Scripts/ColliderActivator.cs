using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActivator : MonoBehaviour
{
    #region Exposed
    [SerializeField]
    BoxCollider2D _hitBoxCollider;
    [SerializeField]
    PlayerController _playerController;

    #endregion



    #region Unity API


    #endregion


    #region Main Methods

    public void ActivateCollider()
    {
        _hitBoxCollider.enabled = true;
        //Debug.Log(_hitBoxCollider.name + " Enable ");
        _playerController.SetAttackTrue();
    }


    public void DeactivateCollider()
    {
        _hitBoxCollider.enabled = false;
        //Debug.Log(_hitBoxCollider.name + " Disable ");
        _playerController.SetAttackFalse();
    }



    #endregion

    #region Privates

    #endregion
}