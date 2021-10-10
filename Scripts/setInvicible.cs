using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setInvicible : MonoBehaviour
{
    #region Exposed
    #endregion

    #region Unity API
    void Awake()
    {
        _playerController = gameObject.transform.parent.GetComponent<PlayerController>();
    }

    #endregion

    #region Main Methods

    public void SetInvicibleTrue()
    {
        _playerController.IsInvicible = true;
        _playerController.SetBool("IsInvincible", true);
    }

    #endregion

    #region Privates

    private PlayerController _playerController;

    #endregion
}