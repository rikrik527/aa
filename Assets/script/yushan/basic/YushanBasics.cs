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
    protected bool canRun;

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
    public static float movementX;
    public static float movementY;
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
    private bool getout = false;
    public static string directions;
    [SerializeField]
    protected Transform target; // object in the 3D World
    protected bool locked = false;
    protected Transform _target; // collision transform which might be yushan player
    private new Transform transform; //yushan transform
    private GameObject[] _gameObj;
    private SpriteRenderer[] _spriteRenderers;
    private Transform[] _trans;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SpriteRenderer[] _spriteRen;
    private GameObject[] _gameObjTarget;
    private GameObject _yushanGameObj;
    private Transform others;

    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveRight = false;
    private bool moveLeft = false;
    public enum Move { up, down, right, left }
    //ui
    [SerializeField]
    protected Text text;
    [SerializeField]
    protected Canvas canvas;
    [SerializeField]
    protected Button button;


    protected LineRenderer lineRender;
    protected float distance;

    private void Init()
    {
        Debug.Log("int");
        _playerAnim = GetComponent<PlayerAnimations>();

        anim = GetComponentInChildren<Animator>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        rid = GetComponent<Rigidbody2D>();

        _targetAnim = GameObject.Find("target").GetComponent<TargetAnimations>();
        transform = GetComponent<Transform>();//get yushan
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _gameObjTarget = GameObject.FindGameObjectsWithTag("npc-collision");
        _yushanGameObj = GameObject.FindGameObjectWithTag("collision");
        lineRender = GameObject.FindGameObjectWithTag("line").GetComponent<LineRenderer>();

    }
    private void Start()
    {

        Init();
        if (lineRender != null)
        {
            lineRender.positionCount = 2;//line render between 2 object
        }




    }
    private void Update()
    {

        movementX = Input.GetAxis("Horizontal");
        //movementX = CrossPlatformInputManager.GetAxis("Horizontal");
        //movementY = CrossPlatformInputManager.GetAxis("Vertical");
        movementY = Input.GetAxis("Vertical");
        rotateY = Input.GetAxis("Horizontal") * tiltAngle;//roads rotatey
                                                          //groundRotateY();

        FindClosestEnemy();


    }
    private void FixedUpdate()
    {
        moveCharacter();



    }




    private void moveCharacter()
    {
        Debug.Log("movecharacter was called");
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(RunningLv1());// run one second and speed down to 1
            Debug.Log("can run" + canRun);                  //after one minute can run again
            if (canRun == true)
            {
                Run();
                Debug.Log("getkeydown Run");
            }

        }




        if (Input.GetMouseButtonDown(0) || CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            getout = true;
            if (getout == true)
            {
                _playerAnim.GetOut();
                StartCoroutine(GetOutNo());

            }

            Debug.Log("clicked jump button");
        }

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

            rid.MovePosition(rid.position + (new Vector2(movementX * speed, movementY) * Time.deltaTime));

            _playerAnim.Move(movementX);
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
            rid.MovePosition(rid.position + (new Vector2(-movementX * -speed, movementY) * Time.deltaTime));

            _playerAnim.Move(movementX);


        }
        if (movementY > 0.1)
        {
            moveDown = true;



        }
        if (moveDown == true)
        {
            canRun = true;



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
            canRun = true;



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

    private void Run()
    {









        rid.MovePosition(rid.position + (new Vector2(movementX * speed, 0) * Time.deltaTime));


        Debug.Log("movementx" + movementX);
        if (movementX <= -0.1f || movementY <= -0.1f || movementY >= 0.1f)
        {
            Debug.Log("stop all side");
            speed = 1;
        }





    }

    private IEnumerator RunningLv1()
    {
        canRun = true;
        speed = 5;
        yield return new WaitForSeconds(1f);
        speed = 1;
        canRun = false;
        yield return new WaitForSeconds(60f);
        canRun = true;//runing can run again after 60 seconds
    }
    private IEnumerator GetOutNo()
    {
        yield return new WaitForSeconds(1.5f);
        getout = false;
        _playerAnim.StopGetOut();
        Debug.Log("stopgetout le la");
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
                Debug.Log("other" + other);
                float dist = Vector3.Distance(other.position, transform.position);
                Debug.Log("dist" + dist);


            }
            return true;
        }
        return false;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("directions" + directions);
        for (int i = 0; i < _gameObjTarget.Length; i++)
        {

            if (collision.transform.tag == "npc-collision")
            {

                Debug.Log("npc-collision");
                if (directions == "right")
                {
                    Debug.Log("npc collision righjt");

                    _playerAnim.BumpInto();

                    rid.AddForce(transform.forward * speed * Time.deltaTime);
                }
                if (directions == "left")
                {
                    Debug.Log("npc collision left");

                    _playerAnim.BumpInto();

                    rid.AddForce(-transform.forward * speed * Time.deltaTime);
                }

            }
        }
        Debug.Log("ontrigger");
        if (collision.GetComponent<CapsuleCollider2D>() && gameObject.tag == "npc")
        {
            Debug.Log("collision happened");
            collision.GetComponent<CapsuleCollider2D>().gameObject.SetActive(false);
        }


        //bump-into animation



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "npc")
        {
            Debug.Log("yushan hit some one with walk");
            _playerAnim.BumpInto();



            rid.AddForce(transform.forward * 10 * Time.deltaTime, ForceMode2D.Force);
        }
    }








    void FindClosestEnemy()
    {
        float distanceToClosestNpc = Mathf.Infinity;

        Transform closestNpc = null;

        _gameObj = GameObject.FindGameObjectsWithTag("npc");
        _spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();


        for (int i = 0; i < _gameObj.Length; i++)
        {

            for (int a = 0; a < _spriteRenderers.Length; a++)
            {
                float distanceToNpc = (_gameObj[i].transform.position - this.transform.position).sqrMagnitude;

                if (distanceToNpc < distanceToClosestNpc)
                {

                    distanceToClosestNpc = distanceToNpc;
                    closestNpc = _gameObj[i].transform;

                    if (closestNpc.transform.position.y > this.transform.position.y)
                    {
                        spriteRenderer.sortingOrder = 1;
                    }
                    if (closestNpc.transform.position.y < this.transform.position.y)
                    {
                        spriteRenderer.sortingOrder = -1;
                    }
                    if (_gameObj[i].transform.position.y > _gameObj[i].transform.position.y)
                    {
                        Debug.Log("_sp[a]");
                        _gameObj[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
                    }
                    if (_gameObj[i].transform.position.y < _gameObj[i].transform.position.y)
                    {
                        Debug.Log("game[i]" + _gameObj[i]); _gameObj[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
                    }
                }


            }
        }
        lineRender.SetPosition(0, new Vector3(closestNpc.position.x, closestNpc.position.y, 0f));
        lineRender.SetPosition(1, new Vector3(this.transform.position.x, this.transform.position.y, 0f));
        distance = (closestNpc.position - this.transform.position).sqrMagnitude;
        //distanceText.text = distance.ToString();

        Debug.DrawLine(this.transform.position, closestNpc.transform.position);

    }

}







