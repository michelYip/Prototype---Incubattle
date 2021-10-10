using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        _animator.SetFloat("Speed",Mathf.Abs(moveX));

        if(Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("AttackTrigger");
        }
    }

    float moveX;
    Animator _animator;
}
