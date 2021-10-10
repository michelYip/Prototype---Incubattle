using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private float _smoothTimeBack = 0.2f;

    [SerializeField]
    private Vector3 _offsetLeft = new Vector3(-2,0,-5);

    [SerializeField]
    private Vector3 _offset = new Vector3(0, 0, -5);

    [SerializeField]
    private Vector3 _offsetRight = new Vector3(2, 0, -5);

    #endregion

    #region Unity API
    void Awake()
    {
        _newTarget = null;
    }

    void FixedUpdate()
    {
        if (_newTarget == null)
		{
            if (_playerTransform.gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_playerTransform.position.x, 0, _playerTransform.position.z) + _offset, ref _smoothVelocity, _smoothTimeBack);
            else
            {
                if (_playerTransform.localScale.x > 0)
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_playerTransform.position.x, 0, _playerTransform.position.z) + _offsetRight, ref _smoothVelocity, _smoothTime);
                if (_playerTransform.localScale.x < 0)
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_playerTransform.position.x, 0, _playerTransform.position.z) + _offsetLeft, ref _smoothVelocity, _smoothTime);
            }
        }
        else
		{
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_newTarget.position.x, 0, _newTarget.position.z) + _offset, ref _smoothVelocity, _smoothTimeBack);
        }
        
    }
    #endregion

    #region Main Methods

    public Transform NewTarget { get => _newTarget; set => _newTarget = value; }

    #endregion

    #region Privates

    private Vector3 _smoothVelocity;
    private Transform _newTarget;


	#endregion
}