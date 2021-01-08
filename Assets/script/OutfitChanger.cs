using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("sprite to change")]
    public SpriteRenderer bodyPart;
    [Header("sprites to cycle through")]
    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    public void Next()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0;
        }
        bodyPart.sprite = options[currentOption];
    }
    public void Previous()
    {
        currentOption--;
        if(currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }
        bodyPart.sprite = options[currentOption];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
