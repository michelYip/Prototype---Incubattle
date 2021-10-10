using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    #region Exposed
    #endregion


    #region Unity API

    void Update()
    {
        if (transform.childCount <= 0)
            Destroy(gameObject);
    }

    #endregion

    #region Main Methods
    #endregion

    #region Privates    
    #endregion
}