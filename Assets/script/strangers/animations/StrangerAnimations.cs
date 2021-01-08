using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerAnimations : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("npc").GetComponentInChildren<Animator>();
        spriteRenderer = GameObject.FindGameObjectWithTag("npc").GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame

    public void smoke()
    {
        Debug.Log("smoke is called");
  
            Debug.Log("ready to smoke");
            anim.SetBool("smoking", true);
            
        
        
    }

    
}
