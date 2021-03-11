using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;



public abstract class YushanBasics : MonoBehaviour
{
    //數據
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int scores;
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



    //雨珊視線




    protected bool canRun;

    [SerializeField]
    protected Vector2 direction;


    protected Animator anim;
    protected Rigidbody2D rid;
    protected SpriteRenderer spriteRender;
    private PlayerAnimations _playerAnim;


    protected Animator animator;
    protected GameObject flirtEye;
    //test
    private Transform _roads;
    private float movementX;
    private float movementY;
    private float rotateY;
    [SerializeField]
    private float tiltAngle = 60.0f;



    //路人
    [SerializeField]
    public static string npcName;
    [SerializeField]
    protected int npcIndex = 0;
    [SerializeField]
    public static ArrayList npc = new ArrayList();
    private bool getout = false;
    public static string directions;
    [SerializeField]
    protected Transform target; // object in the 3D World
    protected bool locked = false;
    protected Transform _target; // collision transform which might be yushan player
    private new Transform transform; //yushan transform


    private Transform[] _trans;

    [SerializeField]
    private SpriteRenderer[] _spriteRen;
    [SerializeField]
    private GameObject[] _gameObjTarget;
    private GameObject _yushanGameObj;
    private Transform others;

    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveRight = false;
    private bool moveLeft = false;
    public enum Move { up, down, right, left }
    //ui






    //add-on

    //collision stats

    //virtual ground
    [SerializeField]
    private PolygonCollider2D virtualGround;



    private void Init()
    {
        Debug.Log("int");
        _playerAnim = GetComponent<PlayerAnimations>();

        anim = GetComponentInChildren<Animator>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        rid = GetComponent<Rigidbody2D>();


        transform = GetComponent<Transform>();//get yushan

        _gameObjTarget = GameObject.FindGameObjectsWithTag("npc-collision");
        _yushanGameObj = GameObject.FindGameObjectWithTag("collision");


    }
    private void Start()
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



    }




    private void moveCharacter()
    {
        Debug.Log("movecharacter was called");









        if (movementX > 0.1)
        {
            moveRight = true;

        }
        if (moveRight == true)
        {




            if (movementX > 0)
            {
                directions = "right";
                if (directions == "right")
                {

                    spriteRender.flipX = false;

                }

            }
            _playerAnim.Move(movementX);
            rid.MovePosition(rid.position + (new Vector2(movementX * speed, movementY) * Time.deltaTime));


        }



        if (movementX < -0.1)
        {
            moveLeft = true;
            moveRight = false;

        }
        if (moveLeft == true)
        {




            if (movementX < 0)
            {
                Debug.Log("movem,enx < 0");
                directions = "left";
                if (directions == "left")
                {
                    Debug.Log("directions left");

                    spriteRender.flipX = true;

                }

            }
            _playerAnim.Move(movementX);
            rid.MovePosition(rid.position + (new Vector2(-movementX * -speed, movementY) * Time.deltaTime));




        }
        if (movementY > 0.1)
        {
            moveDown = true;



        }
        if (moveDown == true)
        {

            if (movementY > 0)
            {
                directions = "up";
                if (directions == "up")
                {

                    Debug.Log("up" + directions);

                }

            }
            _playerAnim.Move(movementY);

            rid.MovePosition(rid.position + (new Vector2(movementX, movementY * speed) * Time.deltaTime));

        }
        if (movementY < -0.1)
        {
            moveUp = true;
            moveDown = false;


        }
        if (moveUp == true)
        {
            if (movementY < 0)
            {
                directions = "down";
                if (directions == "down")
                {

                    Debug.Log("down" + directions);

                }

            }
            _playerAnim.Move(movementY);


            rid.MovePosition(rid.position + (new Vector2(movementX, -movementY * -speed) * Time.deltaTime));

        }
        if (movementX == 0 && movementY == 0)
        {
            Debug.Log("all false");
            moveUp = false;
            moveDown = false;
            moveRight = false;
            moveLeft = false;
        }
        if (moveLeft == false && moveRight == false && moveDown == false && moveUp == false)
        {
            Debug.Log("playeranim.move(0)");
            _playerAnim.Move(0);
        }

    }



    private IEnumerator GetOutNo()
    {
        yield return new WaitForSeconds(1.5f);
        getout = false;
        _playerAnim.StopGetOut();
        Debug.Log("stopgetout le la");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oncollisionenter2d happened");

        Collider2D collider2D = GetComponent<Collider2D>();

        if (collision != null)
        {

            Debug.Log("npc-collision" + collision.gameObject.tag);

            if (directions == "right")
            {

                Debug.Log("npc collision righjt");

                _playerAnim.BumpInto();
                collider2D.attachedRigidbody.AddForce(Vector2.left);




                directions = null;
            }
            if (directions == "left")
            {

                Debug.Log("npc collision left");

                _playerAnim.BumpInto();

                collider2D.attachedRigidbody.AddForce(Vector2.right);

                directions = null;
            }

        }
        else if (collision.transform.tag == "static-block")
        {
            Debug.Log("collision with" + collision);
            return;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        _playerAnim.BumpIntoOff();
    }



















}






