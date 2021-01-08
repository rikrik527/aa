using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetAnimations : MonoBehaviour
{
    [SerializeField]
    private Image[] photos;
    private int photosIndex = 0;
    [SerializeField]
    private Transform _trans;
    private Animator _anim;
    void Start()
    {
        
        _trans = GetComponent<Transform>();
        _anim = GetComponentInChildren<Animator>();
    }
    public void PlayAnimation()
    {
        _anim.Play("target");
    }
    public void TargetSelect()
    {
        _anim.SetBool("locked", true);
        _anim.SetTrigger("target");
        Debug.Log("i was triggered");
        PlayAnimation();
       
    }
    public void TargetNotSelect()
    {
        Debug.Log("locked setbool is false");
        _anim.SetBool("locked", false);
    }
    
}
