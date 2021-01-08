using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Actions : MonoBehaviour
{
    private Canvas _canvas;
    private AbilityAnimations abilityAnimations; 
    // Start is called before the first frame update
    protected Button action, ability;
    public virtual void Init()
    {
        action = GameObject.FindGameObjectWithTag("action").GetComponent<Button>();
        ability = GameObject.FindGameObjectWithTag("ability").GetComponent<Button>();
        abilityAnimations = GameObject.FindGameObjectWithTag("ability").GetComponent<AbilityAnimations>();
    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void ShowActions()
    {
        abilityAnimations.Playing();
    }
    
}
