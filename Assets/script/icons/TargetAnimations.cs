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

    public void TargetSelect()
    {
        _anim.SetBool("locked", true);
        _anim.SetTrigger("target");



    }
    public void idle()
    {

        _anim.SetBool("locked", false);
        Debug.Log("target idle");


    }

}
