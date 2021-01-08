using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityAnimations : MonoBehaviour
{
    private Button _button;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _button = GetComponent<Button>();
    }

    public void Playing()
    {
        _animator.SetBool("ability", true);
    }
    public void stopPlaying()
    {
        _animator.SetBool("ability", false);
    }
}
