using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private SpriteRenderer _spriteRender;
    private Animator _animator;
    public static string directions;

    private bool moveIsCalled = false;
    void Start()
    {
        _spriteRender = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(float movement)
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            Debug.Log("bug");
            _animator.SetFloat("moving", Mathf.Abs(movement));
        }

        _animator.SetFloat("moving", Mathf.Abs(movement));
        moveIsCalled = true;


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
        _animator.SetBool("bump-into", true);
    }
    public void PrepareToCry()
    {
        _animator.SetBool("cry", true);

        Cry();


    }
    public void Cry()
    {


        _animator.SetBool("cry", true);
        if (moveIsCalled == true)
        {
            StopCry();
        }

    }
    public void StopCry()
    {
        _animator.SetBool("cry", false);
        moveIsCalled = false;
    }
    public void BumpIntoOff()
    {
        _animator.SetBool("bump-into", false);
    }
    public void Run()
    {
        StopCry();
        _animator.SetBool("run", true);
    }
    public void StopRun()
    {

        _animator.SetBool("run", false);
    }
}
