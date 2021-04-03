using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float movementX;
    public float movementY;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    public bool isCarrying;
    public ToolEffect toolEffect;


    public bool isUsingToolUp;
    public bool isUsingToolDown;
    public bool isUsingToolRight;
    public bool isUsingToolLeft;

    public bool isLiftingToolUp;
    public bool isLiftingToolDown;
    public bool isLiftingToolRight;
    public bool isLiftingToolLeft;

    public bool isPickingUp;
    public bool isPickingDown;
    public bool isPickingRight;
    public bool isPickingLeft;

    public bool isSwingingToolDown;
    public bool isSwingingToolUp;
    public bool isSwingingToolRight;
    public bool isSwingingToolLeft;
    public bool isBagDown;
    public bool idleUp;
    public bool idleDown;
    public bool idleLeft;
    public bool idleRight;

    private void Update()
    {
        EventsHandler.CallMovementEvent(movementX, movementY, isWalking, isRunning, isIdle, isCarrying, toolEffect,
         isUsingToolUp, isUsingToolDown,
     isUsingToolRight, isUsingToolLeft,

     isLiftingToolUp, isLiftingToolDown,
     isLiftingToolRight, isLiftingToolLeft,

    isPickingUp, isPickingDown,
     isPickingRight, isPickingLeft,

     isSwingingToolUp, isSwingingToolDown,
     isSwingingToolRight, isSwingingToolLeft,


 //isBumpInto,
 //isCommanding,
 //isSittingDown,
 //isCrying,

 //isShirtUp,
 //isShirtDown,
 //isShirtRight,
 //isShirtLeft,

 //isPantsUp,
 //isPantsDown,
 //isPantsRIght,
 //isPantsLeft,

 //isShoesUp,
 //isShoesDown,
 //isShoesRight,
 //isShoesLeft,

 //isHatsUp,
 //isHatsDown,
 //isHatsRight,
 //isHatsLeft,

 //isHairUp,
 //isHairDown,
 //isHairRight,
 //isHairLeft,
 isBagDown,
 idleUp, idleDown, idleRight, idleLeft);
    }
}
