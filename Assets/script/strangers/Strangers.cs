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
    private new Transform transform; //yushan transform
    private List<Transform> _gameObjList;
    protected GameObject[] _gameObj;
    private Transform[] _trans;
    protected SpriteRenderer spriteRen;
    [SerializeField]
    private List<SpriteRenderer> _spriteRen;
    private GameObject[] gameObjects;
    private Transform other;
    private void Start()
    {

        //_gameObj = GameObject.FindGameObjectsWithTag("npc");
        //foreach (GameObject go in _gameObj)
        //{
        //    Debug.Log("_____" + _gameObj + "00000" + go);
        //}
        //Debug.Log("transform" + transform);
    }


    public virtual void Init()
    {
        Debug.Log("init was called");
        animator = GameObject.FindGameObjectWithTag("npc").GetComponentInChildren<Animator>();
        _targetAnim = GameObject.Find("target").GetComponent<TargetAnimations>();
        _target = _targetAnim.GetComponent<Transform>();
        spriteRenderer = GameObject.FindGameObjectWithTag("sprite").GetComponent<SpriteRenderer>();
        strangerAnimations = GameObject.FindGameObjectWithTag("stranger").GetComponent<StrangerAnimations>();
        gameObjects = GameObject.FindGameObjectsWithTag("npc");
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();



    }
    private void Awake()
    {

        Init();
    }
    public virtual void Update()
    {




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


        if (gameObject.tag == "npc" && locked == false)
        {
            Debug.Log("npc");
            locked = true;
            npcName = transform.name;
            npc.Add(npcName);
            npcIndex++;
            TargetPosition();
            if (hit.TargetInSight(_sight) == true) //make distance function
            {
                Debug.Log("to here hit.targetsight is true");

                hit.AnalyzeInfo();
            }


            if (gameObject.tag != "npc" && locked == true)


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


    private void OnMouseOver()
    {
        CheckDistance();

    }









    //private void FindClosestEnemy()
    //{
    //    float distanceToClosestNpc = Mathf.Infinity;
    //    Transform centerPointNpc = null;
    //    Transform closestNpc = null;
    //    _spriteRen = new List<SpriteRenderer>();
    //    _gameObjList = new List<Transform>();
    //    _gameObj = GameObject.FindGameObjectsWithTag("npc");

    //    for (int i = 0; i < _gameObj.Length; i++)
    //    {

    //        SpriteRenderer renderer = _gameObj[i].GetComponentInChildren<SpriteRenderer>();
    //        Transform game = _gameObj[i].transform;
    //        if (game)
    //        {
    //            Debug.Log("game" + game);
    //            _gameObjList.Add(game);
    //            Debug.Log("gameobjectlist" + _gameObjList);
    //        }
    //        if (renderer)
    //        {
    //            Debug.Log("render" + renderer + _spriteRen);
    //            _spriteRen.Add(renderer);
    //        }
    //        if (_gameObj[i].transform.name == this.transform.name)
    //        {
    //            centerPointNpc = this.transform;
    //            _gameObjList.Remove(centerPointNpc);
    //            Debug.Log("remove List gameobjects" + _gameObjList + "centerpointnpc" + centerPointNpc);
    //        }
    //        float distanceToNpc = (game.position - centerPointNpc.position).sqrMagnitude;

    //        if (distanceToNpc < distanceToClosestNpc)
    //        {

    //            distanceToClosestNpc = distanceToNpc;
    //            closestNpc = ;

    //            if (closestNpc.transform.position.y > centerPointNpc.transform.position.y)
    //            {
    //                _spriteRen.sortingOrder = 1;
    //            }
    //            if (closestNpc.transform.position.y < centerPointNpc.transform.position.y)
    //            {
    //                spriteRenderer.sortingOrder = -1;
    //            }

    //        }
    //    }
    //    {

    //    }

    //    Debug.DrawLine(this.transform.position, closestNpc.transform.position);

    //}

}
