using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour, StateInterface
{
    #region Exposed
    #endregion

    #region Unity API
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _dieSFX = transform.Find("DieSFX").GetComponent<AudioSource>();
    }

    #endregion

    #region Main Methods

    public void DoInit()
    {
        _playerController.SetTrigger("DeadTrigger");
        GetComponentInChildren<ColliderActivator>().DeactivateCollider();

        _dieSFX.Play();
    }

    public void DoUpdate()
    {        
        _playerController.GoToDeath();
        _playerController.enabled = false;
    }

    public void DoExit()
    {

    }

    #endregion

    #region Privates

    private PlayerController _playerController;

    private AudioSource _dieSFX;

    #endregion
}