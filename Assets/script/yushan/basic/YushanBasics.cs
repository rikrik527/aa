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



    protected LineRenderer lineRender;


    //add-on

    //collision stats
    private PolygonCollider2D polygonCollider2D;



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



        if (collision != null)
        {

            Debug.Log("npc-collision" + collision);

            if (directions == "right")
            {

                Debug.Log("npc collision righjt");

                _playerAnim.BumpInto();




                directions = null;
            }
            if (directions == "left")
            {

                Debug.Log("npc collision left");

                _playerAnim.BumpInto();



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
                    if (closestNpc.transform.position.y > _gameObj[i].transform.position.y)
                    {
                        Debug.Log("_sp[a]");
                        _gameObj[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
                    }
                    if (closestNpc.transform.position.y < _gameObj[i].transform.position.y)
                    {
                        Debug.Log("game[i]" + _gameObj[i]); _gameObj[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
                    }
                }


            }
        }
        lineRender.SetPosition(0, new Vector3(closestNpc.position.x, closestNpc.position.y, 0f));
        lineRender.SetPosition(1, new Vector3(this.transform.position.x, this.transform.position.y, 0f));



        Debug.DrawLine(this.transform.position, closestNpc.transform.position);

    }


}







