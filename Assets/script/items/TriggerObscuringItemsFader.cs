using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObscuringItemsFader : MonoBehaviour
{
    //get the gameobject we have collided with and then get all the obscuring item fader components on it and its children and then trigger the fadeout

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObscuringItemsFader[] obscuringItemsFaders = collision.gameObject.GetComponentsInChildren<ObscuringItemsFader>();

        if (obscuringItemsFaders.Length > 0)
        {
            for (int i = 0; i < obscuringItemsFaders.Length; i++)
            {
                obscuringItemsFaders[i].FadeOut();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ObscuringItemsFader[] obscuringItemsFaders = collision.gameObject.GetComponentsInChildren<ObscuringItemsFader>();
        if (obscuringItemsFaders.Length > 0)
        {
            for (int i = 0; i < obscuringItemsFaders.Length; i++)
            {
                obscuringItemsFaders[i].FadeIn();
            }
        }
    }
}
