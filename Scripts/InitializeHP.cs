using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeHP : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    PlayerStatsScriptable _playerCurrentStatsScriptable;

    [SerializeField]
    PlayerStatsScriptable _playerBaseStatsScriptable;

    #endregion

    #region Unity API
    void Awake()
    {
        _playerCurrentStatsScriptable.HealthPoint = _playerBaseStatsScriptable.HealthPoint;
        _playerCurrentStatsScriptable.MoveSpeed = _playerBaseStatsScriptable.MoveSpeed;
        _playerCurrentStatsScriptable.JumpHeight = _playerBaseStatsScriptable.JumpHeight;
        _playerCurrentStatsScriptable.IFrameDuration = _playerBaseStatsScriptable.IFrameDuration;
        _playerCurrentStatsScriptable.Score = _playerBaseStatsScriptable.Score;
    }

    #endregion

    #region Main Methods
    #endregion

    #region Privates
    #endregion
}