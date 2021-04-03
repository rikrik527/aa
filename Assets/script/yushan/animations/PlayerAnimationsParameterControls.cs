
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
        Debug.Log("onenabled");
    }
    private void OnDisable()
    {
        Debug.Log("ondisabled");
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
bool isBagDown,
bool idleUp, bool idleDown,
bool idleRight, bool idleLeft)
    {
        Debug.Log("setamimationparamaters");
        animator.SetFloat(Settings.movementX, movementX);
        animator.SetFloat(Settings.movementY, movementY);
        animator.SetBool(Settings.isWalking, isWalking);
        animator.SetBool(Settings.isRunning, isRunning);
        Debug.Log("playeranimationparamatercontrols" + Settings.movementX + "movementx" + movementX);
        animator.SetInteger(Settings.toolEffect, (int)toolEffect);
        animator.SetBool(Settings.isIdle, isIdle);
        animator.SetBool(Settings.isCarrying, isCarrying);
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

        if (isBagDown)
            animator.SetBool(Settings.isBagDown, isBagDown);

        if (idleUp)
            animator.SetTrigger(Settings.idleUp);
        if (idleDown)
            Debug.Log("idledown" + idleDown + Settings.idleDown);
        animator.SetTrigger(Settings.idleDown);
        if (idleLeft)
            animator.SetTrigger(Settings.idleLeft);
        if (idleRight)
            animator.SetTrigger(Settings.idleRight);

    }

    private void AnimationEventPlayFootStepSound()
    {


    }
}
