using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{

    private static UImanager _instance;

    public static UImanager Instance
    {
        get
        {
            if (_instance != null)
            {
                throw new System.Exception();
            }
            return _instance;
        }
    }

    public Button _actions, _punch;
    private void Awake()
    {
        _instance = this;
    }
    public void ActionsOpen()
    {
        Debug.Log("clicked buttton");
        _actions.GetComponent<Animator>().SetBool("open-actions", true);
    }
    public void SwitchPunch()
    {
        _actions.GetComponent<Animation>().Play(string.Empty);
    }
}
