using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private BoxCollider2D m_Collider;
    private Vector3 m_Size;
    Vector3 m_Center;
    Vector3 m_Min, m_Max;
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

        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider2D>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        m_Center = m_Collider.bounds.center;
        //Output to the console the size of the Collider volume

    }
    public void Start()
    {
        Init();



    }
    private void Update()
    {
        Debug.Log("Collider Size : " + m_Size + m_Collider.gameObject.name);
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        rotateY = Input.GetAxis("Horizontal") * tiltAngle;//roads rotatey
        OutputData();                                                //groundRotateY();


    }
    private void FixedUpdate()
    {
        moveCharacter();
        Flip();


    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }


    private void moveCharacter()
    {


        bool moveUp = false;
        bool moveDown = false;
        bool moveRight = false;
        bool moveLeft = false;

        if (movementX > 0.1)
        {
            moveRight = true;

        }
        if (moveRight == true)
        {


            rid.MovePosition(rid.position + (new Vector2(movementX * speed, movementY) * Time.deltaTime));
            _playerAnim.Move(movementX);

        }
        if (movementX < -0.1)
        {
            moveLeft = true;

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

                Debug.Log(transform + "lalala" + other.transform + "" + dist);

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





