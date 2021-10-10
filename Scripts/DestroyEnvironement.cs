using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnvironement : MonoBehaviour
{
    #region Exposed

    #endregion

    #region Unity API

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHitbox"))
        {
            if (!_animator.GetBool("IsBroke"))
                _audioSource.Play();
            _animator.SetBool("IsBroke", true);
            
            try
            {
                GetComponent<CircleCollider2D>().enabled = false;
            }
            catch
            { }
        }
    }
    #endregion

    #region Main Methods
    #endregion

    #region Privates
    private Animator _animator;
    private AudioSource _audioSource;
    #endregion
}