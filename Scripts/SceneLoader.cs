using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private StringVariable _currentScene;
        
    [SerializeField]
    PlayerStatsScriptable _playerCurrentStatsScriptable;
    [SerializeField]
    PlayerStatsScriptable _playerBaseStatsScriptable;

    #endregion

    #region Unity API
    void Awake()
    {
        if(SceneManager.GetActiveScene().name != "GameOver")
            _currentScene.Name = SceneManager.GetActiveScene().name;
    }   
    
    #endregion

    #region Main Methods

    public void Retry()
    {
        SceneManager.LoadScene(_currentScene.Name);

        _playerCurrentStatsScriptable.HealthPoint = _playerBaseStatsScriptable.HealthPoint;
        _playerCurrentStatsScriptable.MoveSpeed = _playerBaseStatsScriptable.MoveSpeed;
        _playerCurrentStatsScriptable.JumpHeight = _playerBaseStatsScriptable.JumpHeight;
        _playerCurrentStatsScriptable.IFrameDuration = _playerBaseStatsScriptable.IFrameDuration;
        _playerCurrentStatsScriptable.Score = _playerBaseStatsScriptable.Score;
    }

    #endregion

    #region Privates
    #endregion
}