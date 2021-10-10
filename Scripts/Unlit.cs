using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlit : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Image _blackDeath;

    #endregion

    #region Unity API
    void Awake()
    {
        
    }

    void Update()
    {
        _chrono -= Time.deltaTime;
        _blackDeath.color = new Color(0, 0, 0, _chrono / 0.3f);
        if (_blackDeath.color.a <= 0)
            _blackDeath.enabled = false;
    }
    #endregion

    #region Main Methods
    #endregion

    #region Privates

    private float _chrono = 1;

    #endregion
}