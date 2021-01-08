using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public class Judo : Strangers
//{


//    // Start is called before the first frame update
//    void Start()
//    {

//    }
//    public override void Init()
//    {
//        base.Init();
//    }

//    public override void OnMouseDown()
//    {
//        Debug.Log("judo");
//        base.OnMouseDown();
//    }

//}
public class Judo : Strangers, YushanAbility
{
    public int Attentions { get; set; }

    public bool Sight { get; set; }


    private new void Start()
    {
        StrangerData kevin = new StrangerData
        {
            Attentions = 5,
            Sight = false,
            Health = 5
        };


    }






    public override void OnMouseDown()
    {
        base.OnMouseDown();
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

        Debug.Log("judo running analyzinginfo");

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
