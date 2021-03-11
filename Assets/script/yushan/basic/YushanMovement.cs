using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class YushanMovement : SingletonYushanBasic<YushanMovement>
{
    private float movementX;
    private float movementY;
    private bool isWalking;
    private bool isRunning;
    private bool isIdle;
    private bool isCarrying;


    private bool isUsingToolUp;
    private bool isUsingToolDown;
    private bool isUsingToolRight;
    private bool isUsingToolLeft;

    private bool isLiftingToolUp;
    private bool isLiftingToolDown;
    private bool isLiftingToolRight;
    private bool isLiftingToolLeft;

    private bool isPickingUp;
    private bool isPickingDown;
    private bool isPickingRight;
    private bool isPickingLeft;

    private bool isSwingingToolDown;
    private bool isSwingingToolUp;
    private bool isSwingingToolRight;
    private bool isSwingingToolLeft;
    //original animations
    //private bool isBumpInto;
    //private bool isCommanding;
    //private bool isSittingDown;
    //private bool isCrying;
    ////editional shirts pants shoes hair hats
    //private bool isShirtDown;
    //private bool isShirtUp;
    //private bool isShirtRight;
    //private bool isShirtLeft;

    //private bool isPantsUp;
    //private bool isPantsDown;
    //private bool isPantsRIght;
    //private bool isPantsLeft;

    //private bool isShoesDown;
    //private bool isShoesUp;
    //private bool isShoesRight;
    //private bool isShoesLeft;

    //private bool isHatsUp;
    //private bool isHatsDown;
    //private bool isHatsRight;
    //private bool isHatsLeft;

    //private bool isHairUp;
    //private bool isHairDown;
    //private bool isHairRight;
    //private bool isHairLeft;

    // share animations paramater
    //public static int isIdleRight;
    //public static int isIdleLeft;

    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rigidbody2D;

    private Direction PlayerDirection;

    private float movementSpeed;

    private bool _playerInputIsDisabled = false;

    public bool PlayerInputIsDiabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }

    protected override void Awake()
    {
        base.Awake();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ResetAnimationTrigger();
        PlayerMovementInput();
        PlayerWalkInput();

        //send event to any listeners for player movement input
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
 false, false, false, false);
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        Vector2 move = new Vector2(movementX * movementSpeed * Time.deltaTime, movementY * movementSpeed * Time.deltaTime);
        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }
    private void ResetAnimationTrigger()
    {
        isUsingToolUp = false;
        isUsingToolDown = false;
        isUsingToolRight = false;
        isUsingToolLeft = false;

        isLiftingToolUp = false;
        isLiftingToolDown = false;
        isLiftingToolRight = false;
        isLiftingToolLeft = false;

        isPickingUp = false;
        isPickingDown = false;
        isPickingRight = false;
        isPickingLeft = false;

        isSwingingToolUp = false;
        isSwingingToolDown = false;
        isSwingingToolRight = false;
        isSwingingToolLeft = false;


        //isBumpInto = false;
        //isCommanding = false;
        //isSittingDown = false;
        //isCrying = false;
        toolEffect = ToolEffect.none;
    }
    private void PlayerMovementInput()
    {
        movementY = Input.GetAxisRaw("Vertical");
        movementX = Input.GetAxisRaw("Horizontal");
        if (movementY != 0 && movementX != 0)
        {
            Debug.Log("moveY!= 0 and X not 0 so x = x * 0.71 same as Y");
            movementX = movementX * 0.71f;
            movementY = movementY * 0.71f;
        }
        if (movementX != 0 || movementY != 0)
        {
            Debug.Log("xy != 0 think is time to run");
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
            //capture player direction for save game
            if (movementX < 0)
            {
                Debug.Log("x < 0 is left");
                PlayerDirection = Direction.left;
            }
            else if (movementX > 0)
            {
                Debug.Log("x > 0 is right");
                PlayerDirection = Direction.right;
            }
            else if (movementY < 0)
            {
                Debug.Log("y < 0 is down");
                PlayerDirection = Direction.down;
            }
            else
            {
                Debug.Log("y > 0 is up");
                PlayerDirection = Direction.up;
            }
        }
        else if (movementX == 0 && movementY == 0)
        {
            Debug.Log("idle");
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }
    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("walking");
            isRunning = false;
            isWalking = true;
            isIdle = true;
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            Debug.Log("running" + Settings.isPickingUp);
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }
    //public void Awake()
    //{
    //    base.Awake();
    //}

    //public void Start()
    //{
    //    base.Init();
    //}

    //public void Update()
    //{
    //    base.Update();
    //}
    //public void FixedUpdate()
    //{
    //    base.FixedUpdate();
    //}




    ////[SerializeField]
    ////private LayerMask _groundLayer;
    ////[SerializeField]
    ////private float _speed;
    ////[SerializeField]
    ////private float _JumpForce;
    ////private bool _grounded = false;
    ////private bool _resetJump = false;

    //private float move;

    //private SpriteRenderer _spriteRender;
    //private SpriteRenderer _spriteEffect;
    //private PlayerAnimations _playerAnim;
    //private Rigidbody2D _ridgi;

    //void Awake()
    //{
    //    _ridgi = GetComponent<Rigidbody2D>();
    //    _playerAnim = GetComponent<PlayerAnimations>();
    //    _spriteRender = GetComponentInChildren<SpriteRenderer>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Movement();
    //    if(Input.GetMouseButton(0) && IsGrounded() == true){
    //       return;
    //    }
    //}
    //void Movement()
    //{
    //    move = Input.GetAxisRaw("Horizontal");
    //    _grounded = IsGrounded();
    //    Flip();

    //    if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()== true)
    //    {
    //        Debug.Log("jump");

    //        _ridgi.velocity = new Vector2(_ridgi.velocity.x, _JumpForce);

    //        StartCoroutine(ResetJumpRoutine());
    //    }
    //    _ridgi.velocity = new Vector2(move * _speed, _ridgi.velocity.y);
    //    _playerAnim.Move(move);
    //}
    //bool IsGrounded()
    //{
    //    RaycastHit2D hitInfo =  Physics2D.Raycast(transform.position, Vector2.down,1f, _groundLayer);
    //    Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);
    //    Debug.Log(hitInfo);

    //    if (hitInfo != null)

    //    {
    //        if(_resetJump == false)
    //        {


    //            return true;
    //        }
    //    }
    //    return false;
    //}
    //void Flip()
    //{
    //    if(move > 0)
    //    {
    //        _spriteRender.flipX = false;





    //        }
    //    if(move < 0)
    //    {
    //        _spriteRender.flipX = true;




    //    }

    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    int back = 32;
    //    Debug.Log("collision!!");

    //    if (collision.collider.gameObject.name == "stranger")
    //    {
    //        Debug.Log("yushan" + collision.collider.gameObject.name);
    //        _spriteRender.sortingOrder = 37;


    //        if(collision.collider.tag == "stranger")
    //        {

    //            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //            _spriteRender.sortingOrder = 37;
    //            Debug.Log("ignore coliision" + _spriteRender.sortingOrder);
    //        }

    //    }
    //    if (collision.collider.gameObject.name == null)
    //    {
    //        Debug.Log("do nothing");
    //        return;
    //    }
    //    else if (collision.collider.gameObject.name != "stranger")
    //    {
    //        Debug.Log("collision" + collision.collider.gameObject.name);
    //        _spriteRender.sortingOrder = back;
    //        Debug.Log("not yushan" + _spriteRender.sortingOrder);
    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("triggerenter");
    //    if (other.gameObject.tag == "stranger")
    //    {
    //        Debug.Log("onentertrigger");
    //        _playerAnim.collisionFall();
    //    }
    //}

    //IEnumerator ResetJumpRoutine()
    //    {
    //        _resetJump = true;
    //        yield return new WaitForSeconds(3f);
    //        _resetJump = false;
    //    }
}
