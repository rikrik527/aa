using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTime : MonoBehaviour
{

    private DateTime localDateTime = DateTime.Now;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("lala"+localDateTime.ToString());
    }
}
