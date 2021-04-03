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
        Debug.Log("selecting");
        _animator.SetBool("selected", true);
        _animator.SetBool("not-select", false);
    }
    public void NotSelect()
    {
        Debug.Log("not-select is called");
        _animator.SetBool("selected", false);
        _animator.SetBool("not-select", true);
    }
}
