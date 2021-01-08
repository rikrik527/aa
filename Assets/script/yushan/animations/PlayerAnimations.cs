using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private SpriteRenderer _spriteRender;
    private Animator _animator;
    void Start()
    {
        _spriteRender = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(float movement)
    {
        _animator.SetBool("right-idle", false);
        _animator.SetBool("left-idle", false);
        _animator.SetBool("stop", false);
        _animator.SetFloat("moving", Mathf.Abs(movement));

    }
    public void StopMove()
    {
        _animator.SetBool("stop", true);
    }


    public void TurnLeft()
    {
        Debug.Log("turn left");
        _animator.SetBool("left", true);
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("turn-left"))
        {
            Debug.Log("idle");
            _animator.SetBool("left-idle",true);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            Debug.Log("stop walk");
            StopMove();
        }
    }
    public void TurnRight()
    {
        _animator.SetBool("right", true);
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("turn-right"))
        {
            Debug.Log("idle");
            _animator.SetBool("right-idle", true);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            Debug.Log("stop walk");
            StopMove();
        }
    }
}
