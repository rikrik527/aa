using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private SpriteRenderer _spriteRender;
    private Animator _animator;
    public static string directions;
    void Start()
    {
        _spriteRender = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(float movement)
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            Debug.Log("iswalking");
            _animator.SetBool("get-out", false);

        }

        _animator.SetFloat("moving", Mathf.Abs(movement));


    }

    public void StopGetOut()
    {
        _animator.SetBool("get-out", false);
    }
    public void GetOut()
    {
        _animator.SetBool("get-out", true);
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            Debug.Log("is walk");
            StopGetOut();
        }




    }
    public void BumpInto()
    {
        _animator.SetTrigger("bump-into");
    }


}
