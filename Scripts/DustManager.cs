using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustManager : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private GameObject _jumpDust;

    [SerializeField]
    private GameObject _landDust;

    [SerializeField]
    private GameObject _sprintDust;

    #endregion

    #region Unity API
    void Awake()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Main Methods

    public void EnableJumpDust()
    {
        _jumpDust.SetActive(true);
    }
    public void EnableLandDust()
    {
        _landDust.SetActive(true);
    }
    public void EnableSprintDust()
    {
        _sprintDust.SetActive(true);
    }


    public void DisableDust()
    {
        gameObject.SetActive(false);
    }

    #endregion

    #region Privates
    #endregion
}