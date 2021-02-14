using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingAnimations : MonoBehaviour
{
    public Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Selecting()
    {
        _animator.SetTrigger("selecting-trigger");
        _animator.SetBool("not-select", false);
    }
    public void NotSelect()
    {
        _animator.SetBool("not-select", true);
    }
}
