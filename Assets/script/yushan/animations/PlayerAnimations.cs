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
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("getout"))
        {
            Debug.Log("getout false");
            _animator.SetBool("get-out", false);

        }

        _animator.SetFloat("moving", Mathf.Abs(movement));

    }
    public void StopMove()
    {
        _animator.SetBool("stop", true);
    }



    public void GetOut()
    {
        _animator.SetBool("get-out", true);
        Debug.Log("getout was triggewr");
        StartCoroutine(GetOutFail());
        Debug.Log("1f");



    }
    private IEnumerator GetOutFail()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("wait 1 f");
        _animator.SetBool("get-out", false);
    }


}
