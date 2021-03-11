
using UnityEngine;

public class PlayerAnimationsParameterControls : MonoBehaviour
{

    private Animator animator;
    //use this for initialisastion

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventsHandler.MovementEvent += SetAnimationParameters;
    }
    private void OnDisable()
    {
        EventsHandler.MovementEvent -= SetAnimationParameters;
    }
    private void SetAnimationParameters(float movementX, float movementY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
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
        Debug.Log("setamimationparamaters");
        animator.SetFloat(Settings.movementX, movementX);
        animator.SetFloat(Settings.movementY, movementY);
        animator.SetBool(Settings.isWalking, isWalking);
        animator.SetBool(Settings.isRunning, isRunning);

        animator.SetInteger(Settings.toolEffect, (int)toolEffect);

        if (isUsingToolRight)
            animator.SetTrigger(Settings.isUsingToolRight);
        if (isUsingToolLeft)
            animator.SetTrigger(Settings.isUsingToolLeft);
        if (isUsingToolUp)
            animator.SetTrigger(Settings.isUsingToolUp);
        if (isUsingToolDown)
            animator.SetTrigger(Settings.isUsingToolDown);


        if (isLiftingToolRight)
            animator.SetTrigger(Settings.isLiftingToolRight);
        if (isLiftingToolLeft)
            animator.SetTrigger(Settings.isLiftingToolLeft);
        if (isLiftingToolUp)
            animator.SetTrigger(Settings.isLiftingToolUp);
        if (isLiftingToolDown)
            animator.SetTrigger(Settings.isLiftingToolDown);


        if (isSwingingToolRight)
            animator.SetTrigger(Settings.isSwingingToolRight);
        if (isSwingingToolLeft)
            animator.SetTrigger(Settings.isSwingingToolLeft);
        if (isSwingingToolUp)
            animator.SetTrigger(Settings.isSwingingToolUp);
        if (isSwingingToolDown)
            animator.SetTrigger(Settings.isSwingingToolDown);


        if (isPickingRight)
            animator.SetTrigger(Settings.isPickingRight);
        if (isPickingLeft)
            animator.SetTrigger(Settings.isPickingLeft);
        if (isPickingUp)
            animator.SetTrigger(Settings.isPickingUp);
        if (isPickingDown)
            animator.SetTrigger(Settings.isPickingDown);


        if (isIdleUp)
            animator.SetTrigger(Settings.isIdleUp);
        if (isIdleDown)
            animator.SetTrigger(Settings.isIdleDown);
        if (isIdleLeft)
            animator.SetTrigger(Settings.isIdleLeft);
        if (isIdleRight)
            animator.SetTrigger(Settings.isIdleRight);

    }

    private void AnimationEventPlayFootStepSound()
    {


    }
}
