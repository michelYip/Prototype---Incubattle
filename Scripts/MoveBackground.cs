using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Transform _stopPoint;

    public float _smoothTime;

    #endregion

    #region Unity API

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _stopPoint.position, ref _smoothVelocity, _smoothTime);
    }

    #endregion

    #region Main Methods
    #endregion

    #region Privates

    private Vector3 _smoothVelocity;

    #endregion
}