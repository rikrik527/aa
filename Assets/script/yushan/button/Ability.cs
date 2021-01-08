using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ability : MonoBehaviour
{
    private AbilityAnimations abilityAnimations;
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        abilityAnimations = GetComponent<AbilityAnimations>();
    }

    private void CloseAbility()
    {
        Debug.Log("stop");
        abilityAnimations.stopPlaying();
    }
}
