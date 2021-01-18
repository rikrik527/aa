using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public abstract class YushanBasics : MonoBehaviour
{
    //數據
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int money;
    [SerializeField]
    protected int skillPoint;
    [SerializeField]
    protected int impression;//好感度
    [SerializeField]
    protected int popularity;//聲望


    [SerializeField]
    protected ArrayList nicknames = new ArrayList();
    [SerializeField]
    protected int speed;
    protected float ButtonCooler = 0.5f; // Half a second before reset
    protected int ButtonCount = 0;


    //雨珊視線
    protected bool _sight = false;
    [SerializeField]
    protected GameObject eyeVision;

    [SerializeField]
    protected Transform[] waypoints;
    protected int waypointsIndex = 0;


    [SerializeField]
    protected Vector2 direction;


    protected Animator anim;
    protected Rigidbody2D rid;
    protected SpriteRenderer spriteRender;
    private PlayerAnimations _playerAnim;
    private TargetAnimations _targetAnim;

    protected Animator animator;
    protected GameObject flirtEye;
    //test
    private Transform _roads;
    private float movementX;
    private float movementY;
    private float rotateY;
    [SerializeField]
    private float tiltAngle = 60.0f;


    //targetdistance
    public Transform other;
    //路人
    [SerializeField]
    public static string npcName;
    [SerializeField]
    protected int npcIndex = 0;
    [SerializeField]
    public static ArrayList npc = new ArrayList();



    [SerializeField]
    protected Transform target; // object in the 3D World
    protected bool locked = false;
    protected Transform _target; // collision transform which might be yushan player
    private void Init()
    {
        Debug.Log("int");
        _playerAnim = GetComponent<PlayerAnimations>();

        anim = GetComponentInChildren<Animator>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        rid = GetComponent<Rigidbody2D>();

        _targetAnim = GameObject.Find("target").GetComponent<TargetAnimations>();



    }
    public void Start()
    {
        Init();



    }
    private void Update()
    {

        movementX = Input.GetAxis("Horizontal");
        //movementX = CrossPlatformInputManager.GetAxis("Horizontal");
        //movementY = CrossPlatformInputManager.GetAxis("Vertical");
        movementY = Input.GetAxis("Vertical");
        rotateY = Input.GetAxis("Horizontal") * tiltAngle;//roads rotatey
                                                          //groundRotateY();


    }
    private void FixedUpdate()
    {
        moveCharacter();
        Flip();


    }




    private void moveCharacter()
    {
        Debug.Log("movecharacter was called");

        bool moveUp = false;
        bool moveDown = false;
        bool moveRight = false;
        bool moveLeft = false;
        float right = 0f;


        Debug.Log("movementx" + movementX + "move4mentY" + movementY);
        if (Input.GetMouseButtonDown(0) || CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            _playerAnim.GetOut();
            Debug.Log("clicked jump button");
        }

        if (movementX > 0.1)
        {
            moveRight = true;

        }
        if (moveRight == true)
        {


            rid.MovePosition(rid.position + (new Vector2(movementX * speed, movementY) * Time.deltaTime));
            _playerAnim.Move(movementX);
            if (Input.GetKeyDown(KeyCode.D))
            {


                if (ButtonCooler > 0 && ButtonCount == 1)
                {


                    speed = 5;
                    rid.MovePosition(rid.position + (new Vector2(movementX * speed, 0) * Time.deltaTime));
                    Debug.Log("movementx" + movementX);
                    if (movementX <= -0.1f || movementY <= -0.1f || movementY >= 0.1f)
                    {
                        Debug.Log("stop all side");
                        speed = 1;
                    }
                }
                else
                {
                    ButtonCooler = 0.5f;
                    ButtonCount += 1;
                }
            }

            if (ButtonCooler > 0)
            {

                ButtonCooler -= 1 * Time.deltaTime;

            }
            else
            {
                ButtonCount = 0;
            }
        }



        if (movementX < -0.1)
        {
            moveLeft = true;
            moveRight = false;

        }
        if (moveLeft == true)
        {


            rid.MovePosition(rid.position + (new Vector2(-movementX * -speed, movementY) * Time.deltaTime));
            _playerAnim.Move(movementX);

        }
        if (movementY > 0.1)
        {
            moveDown = true;



        }
        if (moveDown == true)
        {

            rid.MovePosition(rid.position + (new Vector2(movementX, movementY * speed) * Time.deltaTime));
            _playerAnim.Move(movementY);
        }
        if (movementY < -0.1)
        {
            moveUp = true;
            moveDown = false;


        }
        if (moveUp == true)
        {

            rid.MovePosition(rid.position + (new Vector2(movementX, -movementY * -speed) * Time.deltaTime));
            _playerAnim.Move(movementY);
        }
        if (movementX == 0 && movementY == 0)
        {
            moveUp = false;
            moveDown = false;
            moveRight = false;
            moveLeft = false;
        }
        if (moveLeft == false && moveRight == false && moveDown == false && moveUp == false)
        {

            _playerAnim.Move(0);
        }

    }


    public virtual void OnMouseDown()
    {
        Debug.Log("mousedown on yushan" + gameObject.tag);
        if (gameObject.tag == "npc")
        {
            Debug.Log("tarhetdistance on yushanbasic");
            TargetDistance();
        }
    }
    bool TargetDistance()
    {
        Debug.Log("targetDistance fires");
        if (Input.GetMouseButtonDown(0))
        {

            other = GameObject.FindGameObjectWithTag("npc").GetComponent<Transform>();
            if (other)
            {

                float dist = Vector3.Distance(other.position, transform.position);



            }
            return true;
        }
        return false;

    }


    void Flip()
    {
        if (movementX < 0)
        {
            spriteRender.flipX = true;
        }
        else if (movementX > 0)
        {
            spriteRender.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ontrigger");
        if (collision.GetComponent<CapsuleCollider2D>() && gameObject.tag == "npc")
        {
            Debug.Log("collision happened");
            collision.GetComponent<CapsuleCollider2D>().gameObject.SetActive(false);
        }
    }


}





