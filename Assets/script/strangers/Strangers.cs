using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public abstract class Strangers : MonoBehaviour
{

    //datas 路人數據 
    [SerializeField]
    protected int attentions;
    [SerializeField]
    protected int informations;
    [SerializeField]
    protected Array[] names;
    protected Array[] jobTitles;
    protected string jobTitle;
    protected int salary;
    private string G = "元";
    [SerializeField]
    protected Image[] infoPhotos;
    private int infoIndex = 0;
    [SerializeField]
    protected string npcName;
    [SerializeField]
    protected int npcIndex = 0;
    [SerializeField]
    protected ArrayList npc = new ArrayList();



    protected StrangerAnimations strangerAnimations;
    protected TargetAnimations _targetAnim;
    [SerializeField]
    protected GameObject obj;

    [SerializeField]
    protected int targetIndex = 0;
    [SerializeField]
    protected Transform[] points;
    protected int pointsIndex = 0;
    protected int i;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected bool smoking = false;
    [SerializeField]
    protected new Camera camera;
    // Camera containing the canvas
    [SerializeField]
    protected Transform target; // object in the 3D World
    protected bool locked = false;
    protected Transform _target; // collision transform which might be yushan player

    //yushanAbility titles tile 號稱[]
    [SerializeField]
    protected string[] titles = { "super", "man", "i" };
    [SerializeField]
    protected string title;
    //雨珊視線
    protected bool _sight = false;
    [SerializeField]
    protected GameObject eyeVision;
    protected CapsuleCollider2D cap2D;



    public virtual void Init()
    {
        Debug.Log("init was called");
        animator = GameObject.FindGameObjectWithTag("npc").GetComponentInChildren<Animator>();
        _targetAnim = GameObject.Find("target").GetComponent<TargetAnimations>();
        _target = _targetAnim.GetComponent<Transform>();
        spriteRenderer = GameObject.FindGameObjectWithTag("sprite").GetComponent<SpriteRenderer>();
        strangerAnimations = GameObject.FindGameObjectWithTag("stranger").GetComponent<StrangerAnimations>();


    }
    private void Awake()
    {

        Init();
    }
    public virtual void Update()
    {
        if (animator == null)
        {
            Debug.Log("error");
        }
        else
        {
            kevinSmoke();
            Debug.Log(animator + "animator is");
        }

    }
    public virtual void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }



    public virtual void OnMouseDown()
    {

        Debug.Log("onmousedown target this" + target + "\n" + this);
        YushanAbility hit = GetComponent<YushanAbility>();
        _sight = true;
        hit.TargetInSight(_sight);
        Debug.Log("stranger sight need to change");


        if (gameObject.tag == "npc")
        {
            locked = true;
            npcName = transform.name;
            npc.Add(npcName);
            npcIndex++;

            if (hit.TargetInSight(_sight) == true) //make distance function
            {
                Debug.Log("to here hit.targetsight is true");
                TargetPosition();
                hit.AnalyzeInfo();
            }


            else if (gameObject.tag != "npc" && locked == true)


            {

                Debug.Log("shit");
                locked = false;
                _targetAnim.TargetNotSelect();



            }
        }





    }
    public void CheckDistance()
    {
        Transform other = GameObject.FindGameObjectWithTag("npc").GetComponent<Transform>();
        if (other)
        {
            float distance = Vector3.Distance(other.position, transform.position);
            Debug.Log(distance);
        }

    }


    private void TargetPosition()
    {
        Debug.Log("targetPosti" + locked);

        Debug.Log("licked true");

        _target.position = transform.position;

        _targetAnim.TargetSelect();



    }

    private IEnumerator CountDownTen()
    {
        yield return new WaitForSeconds(60f);
        strangerAnimations.smoke();

    }
    public virtual void kevinSmoke()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {

            StartCoroutine(CountDownTen());


        }
    }
    private void OnMouseOver()
    {
        CheckDistance();

    }

    //private void OnMouseEnter()
    //{
    //    Debug.Log("this" + this);
    //    Debug.Log("transform" + transform);
    //    Debug.Log("mouseenter");
    //    eyeVision.SetActive(false);
    //}
    //private void OnMouseExit()
    //{
    //    Debug.Log("onmouseexit");

    //    Debug.Log("locked == false && TargetPosition(false)");
    //    eyeVision.SetActive(true);

    //}

}
//void OnMouseOver()
//{
//    if (Input.GetMouseButtonDown(0) == true && other.gameObject.tag == "stranger")
//    {
//        Debug.Log("mouse stranger");
//        target = other.transform;
//        _targetAnim.TargetSelect();
//        Vector3 screenPos = Camera.main.ScreenToWorldPoint(target.position);
//        Vector2 mousePos2D = new Vector2(screenPos.x, screenPos.y);

//        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.up);
//        Debug.DrawRay(transform.position, Vector2.up * mousePos2D, Color.green);
//        if (hit.collider != null)
//        {
//            float h = Screen.height;
//            float w = Screen.width;
//            float x = screenPos.x - (w / 2);
//            float y = screenPos.y - (h / 2);
//            float s = canvas.scaleFactor;
//            icon.anchoredPosition = new Vector2(x, y) / s;
//            Debug.Log("x,y" + screenPos.x + screenPos.y);
//            Debug.Log("target" + target);
//            Debug.Log("hit.collider.gameobjectname" + hit.collider.gameObject.name);

//            hit.collider.attachedRigidbody.AddForce(Vector2.up);
//        }
//    }

//}
