using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kevin : Strangers, YushanAbility
{
    public int Attentions { get; set; }

    public bool Sight { get; set; }


    public override void Init()
    {
        base.Init();
        Attentions = attentions;
        Sight = _sight;

    }

    public override void Update()
    {
        base.Update();
    }



    public override void FixedUpdate()
    {
        Debug.Log("fixedupdate onb kevin");
        base.FixedUpdate();
    }

    public override void kevinSmoke()
    {
        base.kevinSmoke();
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        Debug.Log("kevin mouse down");

    }
    public void Damage()
    {
        Attentions++;
        Debug.Log("damage on kevin" + Attentions);
        if (Attentions > 5)
        {
            Destroy(gameObject);
        }
    }
    public void AnalyzeInfo()
    {

        Debug.Log("kevin running analyzinginfo");

    }

    public bool TargetInSight(bool Sight)
    {
        Debug.Log("bool fires");
        if (Sight == true)
        {
            Debug.Log("no one say is true");
            return true;
        }
        return false;

    }
}
