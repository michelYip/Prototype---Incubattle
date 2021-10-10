using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2OpenDoorCollider : MonoBehaviour
{
    #region Exposed
    #endregion

    #region Unity API
    void Awake()
    {
        _elevatorAudio = GetComponent<AudioSource>();        
    }

    void Update()
    {
        
    }
    #endregion

    #region Main Methods

    public void OpenDoorCollider()
    {
        GetComponentInChildren<EdgeCollider2D>().enabled = false;
        _elevatorAudio.Play();
    }

    #endregion

    #region Privates

    private AudioSource _elevatorAudio;

    #endregion
}