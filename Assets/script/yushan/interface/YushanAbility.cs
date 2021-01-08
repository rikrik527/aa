using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface YushanAbility
{

    bool Sight { get; set; }
    int Attentions { get; set; }

    void Damage();
    void AnalyzeInfo();
    bool TargetInSight(bool Sight);





}
