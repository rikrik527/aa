
using UnityEngine;

public static class Settings
{
    //player movement speed
    public static float runningSpeed = 5.333f;
    public static float walkingSpeed = 2.666f;

    //player movement animations
    public static int movementX;
    public static int movementY;
    public static int isWalking;
    public static int isRunning;
    public static int isIdle;
    public static int isCarrying;
    public static int toolEffect;


    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;

    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;

    public static int isPickingUp;
    public static int isPickingDown;
    public static int isPickingRight;
    public static int isPickingLeft;

    public static int isSwingingToolUp;
    public static int isSwingingToolDown;
    public static int isSwingingToolRight;
    public static int isSwingingToolLeft;
    //animations from original
    //public static int isBumpInto;
    //public static int isCommanding;//same as getout now
    //public static int isSittingDown;
    //public static int isCrying;
    ////editional shirts pants shoes hair hats
    //public static int isShirtUp;
    //public static int isShirtDown;
    //public static int isShirtRight;
    //public static int isShirtLeft;

    //public static int isPantsUp;
    //public static int isPantsDown;
    //public static int isPantsRIght;
    //public static int isPantsLeft;

    //public static int isShoesUp;
    //public static int isShoesDown;
    //public static int isShoesRight;
    //public static int isShoesLeft;

    //public static int isHatsUp;
    //public static int isHatsDown;
    //public static int isHatsRight;
    //public static int isHatsLeft;

    //public static int isHairUp;
    //public static int isHairDown;
    //public static int isHairRight;
    //public static int isHairLeft;

    // share animations paramater
    public static int isIdleUp;
    public static int isIdleDown;
    public static int isIdleRight;
    public static int isIdleLeft;

    static Settings()
    {
        //static constuctor


        movementX = Animator.StringToHash("movementX");
        movementY = Animator.StringToHash("movementY");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        isIdle = Animator.StringToHash("isIdle");
        isCarrying = Animator.StringToHash("isCarrying");
        toolEffect = Animator.StringToHash("toolEffect");


        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");

        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");

        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");
        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingLeft = Animator.StringToHash("isPickingLeft");

        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");

        //animations from original
        //isBumpInto = Animator.StringToHash("isBumpInto");
        //isCommanding = Animator.StringToHash("isCommanding");
        //isSittingDown = Animator.StringToHash("isSittingDown");
        //isCrying = Animator.StringToHash("isCrying");
        ////new animations from yushan
        //isShirtUp = Animator.StringToHash("isShirtUp");
        //isShirtDown = Animator.StringToHash("isShirtDown");
        //isShirtRight = Animator.StringToHash("isShirtRight");
        //isShirtLeft = Animator.StringToHash("isShirtLeft");

        //isPantsUp = Animator.StringToHash("isPantsUp");
        //isPantsDown = Animator.StringToHash("isPantsDown");
        //isPantsRIght = Animator.StringToHash("isPantsRIght");
        //isPantsLeft = Animator.StringToHash("isPantsLeft");

        //isShoesUp = Animator.StringToHash("isShoesUp");
        //isShoesDown = Animator.StringToHash("isShoesDown");
        //isShoesRight = Animator.StringToHash("isShoesRight");
        //isShoesLeft = Animator.StringToHash("isShoesLeft");

        //isHatsUp = Animator.StringToHash("isHatsUp");
        //isHatsDown = Animator.StringToHash("isHatsDown");
        //isHatsRight = Animator.StringToHash("isHatsRight");
        //isHatsLeft = Animator.StringToHash("isHatsLeft");

        //isHairUp = Animator.StringToHash("isHairUp");
        //isHairDown = Animator.StringToHash("isHairDown");
        //isHairRight = Animator.StringToHash("isHairRight");
        //isHairLeft = Animator.StringToHash("isHairLeft");

        //shared animation
        isIdleUp = Animator.StringToHash("isIdleUp");
        isIdleDown = Animator.StringToHash("isIdleDown");
        isIdleRight = Animator.StringToHash("isIdleRight");
        isIdleLeft = Animator.StringToHash("isIdleLeft");
    }
}
