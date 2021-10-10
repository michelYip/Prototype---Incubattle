using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_HealthManager : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private PlayerStatsScriptable _playerCurrentStats;

    [SerializeField]
    private Image _healthFill;

    [SerializeField]
    private Image _blackDeath;
    #endregion

    #region Unity API

    void Awake()
    {
        
    }

    private void Update()
    {
        _healthFill.fillAmount = _playerCurrentStats.HealthPoint / 10f;
        if(_playerCurrentStats.HealthPoint <= 0)
        {
            _chrono += Time.deltaTime;
            _blackDeath.color = new Color(0,0,0, _chrono * 0.4f);

        }
        if (_blackDeath.color.a >= 0.99)
            SceneManager.LoadScene("GameOver");
    }
    #endregion

    #region Main Methods
    #endregion

    #region Privates

    private float _chrono;

    #endregion
}