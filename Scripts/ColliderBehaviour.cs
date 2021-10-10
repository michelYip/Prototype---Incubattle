using UnityEngine;

public class ColliderBehaviour : MonoBehaviour
{
    #region Unity API
    void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    #endregion


    #region Main Methods

    public void EnableCollider()
    {
        _collider2D.enabled = true;
    }

    public void DisableCollider()
    {
        _collider2D.enabled = false;
    }

    #endregion


    #region Privates

    private Collider2D _collider2D;

    #endregion
}