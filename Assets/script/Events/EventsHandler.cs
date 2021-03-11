using System;
using System.Collections.Generic;
using UnityEngine;
public delegate void MovementDelegate(float movementX, float movementY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
        bool isUsingToolUp, bool isUsingToolDown,
    bool isUsingToolRight, bool isUsingToolLeft,

    bool isLiftingToolUp, bool isLiftingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft,

    bool isPickingUp, bool isPickingDown,
    bool isPickingRight, bool isPickingLeft,

    bool isSwingingToolUp, bool isSwingToolDown,
    bool isSwingingToolRight, bool isSwingingToolLeft,

//    bool isBumpInto,
//bool isCommanding,
//bool isSittingDown,
//bool isCrying,

//bool isShirtUp,
//bool isShirtDown,
//bool isShirtRight,
//bool isShirtLeft,

//bool isPantsUp,
//bool isPantsDown,
//bool isPantsRIght,
//bool isPantsLeft,

//bool isShoesUp,
//bool isShoesDown,
//bool isShoesRight,
//bool isShoesLeft,

//bool isHatsUp,
//bool isHatsDown,
//bool isHatsRight,
//bool isHatsLeft,

//bool isHairUp,
//bool isHairDown,
//bool isHairRight,
//bool isHairLeft,

bool isIdleUp, bool isIdleDown,
bool isIdleRight, bool isIdleLeft);


public static class EventsHandler
{
    //movement Event

    public static event MovementDelegate MovementEvent;

    //movement evebt call for publishers

    public static void CallMovementEvent(float movementX, float movementY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
        bool isUsingToolUp, bool isUsingToolDown,
    bool isUsingToolRight, bool isUsingToolLeft,

    bool isLiftingToolUp, bool isLiftingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft,

    bool isPickingUp, bool isPickingDown,
    bool isPickingRight, bool isPickingLeft,

    bool isSwingingToolUp, bool isSwingingToolDown,
    bool isSwingingToolRight, bool isSwingingToolLeft,

//    bool isBumpInto,
//bool isCommanding,
//bool isSittingDown,
//bool isCrying,

//bool isShirtUp,
//bool isShirtDown,
//bool isShirtRight,
//bool isShirtLeft,

//bool isPantsUp,
//bool isPantsDown,
//bool isPantsRIght,
//bool isPantsLeft,

//bool isShoesUp,
//bool isShoesDown,
//bool isShoesRight,
//bool isShoesLeft,

//bool isHatsUp,
//bool isHatsDown,
//bool isHatsRight,
//bool isHatsLeft,

//bool isHairUp,
//bool isHairDown,
//bool isHairRight,
//bool isHairLeft,

bool isIdleUp, bool isIdleDown,
bool isIdleRight, bool isIdleLeft)
    {
        Debug.Log("callmovementevent");
        if (MovementEvent != null)
            Debug.Log("MovementEvent is not null");
        MovementEvent(movementX, movementY, isWalking, isRunning, isIdle, isCarrying, toolEffect,
         isUsingToolUp, isUsingToolDown,
     isUsingToolRight, isUsingToolLeft,

     isLiftingToolUp, isLiftingToolDown,
     isLiftingToolRight, isLiftingToolLeft,

    isPickingUp, isPickingDown,
     isPickingRight, isPickingLeft,

     isSwingingToolUp, isSwingingToolDown,
     isSwingingToolRight, isSwingingToolLeft,

 //    isBumpInto,
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

 isIdleUp, isIdleDown,
 isIdleRight, isIdleLeft);

    }
}
