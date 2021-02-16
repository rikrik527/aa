using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Linq;
using System;

public class CameraEngine : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;//set camera to main camera
    //cinemachinecamera
    [SerializeField]
    private CinemachineVirtualCamera vcam;//this is cam1 original cam

    [SerializeField]
    private GameObject cam1;//set vcam to cam1
    [SerializeField]
    private GameObject cam2;
    [SerializeField]
    private GameObject cam3;
    //this cam4 is for camera property through script for target mouse click on
    [SerializeField]
    private CinemachineVirtualCamera targetCam;
    [SerializeField]
    private CinemachineBrain cinemachineBrain;
    private CinemachineTransposer transposer;

    [SerializeField]
    private Transform none;//set m follow to none


    [SerializeField]
    private Transform other;
    //static target share in exitinformation
    public static Transform target;

    //yushan
    [SerializeField]
    private Transform _yushan;

    [SerializeField]
    private GameObject zoomIn;
    // check if zoom in
    private bool isZoomIn = false;
    //check how many times clicked zoom in
    private int zoomInClickedTimes = 0;

    [SerializeField]
    private GameObject zoomOut;
    // check if zoom out
    private bool isZoomOut = false;
    // check how many times clicked zoom out
    private int zoomOutClickedTimes = 0;

    [SerializeField]
    private Text distanceText;

    public static float distance;
    public static int distanceInt;

    //outline near 0+m
    [SerializeField]
    private Material material;// mouse click spriterenderer turned to outline



    public RectTransform holdingHandGameObject;



    public RectTransform clickHandGameObject;

    public GameObject targetGameObject;
    public RectTransform rectTransform2;
    private Vector2 startHandPosition;
    private float speed = 1000f;
    private Vector2 newPos2;









    // findclosetEnemy function fields
    private GameObject[] _gameObj;
    private SpriteRenderer[] _spriteRenderers;
    private SpriteRenderer spriteRenderer;
    private LineRenderer lineRender;
    //closetNpc set static
    public static Transform closestNpc = null;
    //dialog show fields

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform _selecting;
    private SelectingAnimations selectingAnimations;
    private RectTransform _rectTransform;
    private Image _image;
    private Animator _animator;
    //default field of view static
    public static float defaultFieldOfView = 93f;
    // default camera offset x
    public static float defaultOffsetX = 2f;
    public static float defaultOffsetZ = -3f;
    public static float defaultOffsetY = 1;

    //default select target field of view
    public static float selectedFieldOfView = 39f;
    public static float selectedOffsetX = 0f;
    public static float selectedOffsetY = 0f;
    public static float selectedOffsetZ = -3f;
    //default orthographicsize
    public static float defaultOrthographicSize = 4.8725f;
    //default selected orthgraphicsize
    public static float selectedOrthographicSize = 1f;

    //static canvas talk option
    public RectTransform rectTransform;
    public static Image talkColor;

    //infomationpanel
    [SerializeField]
    private RectTransform infomationPanel;

    //zoomin clicks
    private int clicks = 0;
    private int zoomOutClicks = 0;
    private void Init()
    {
        //findclosetenemy getcomponent
        lineRender = GameObject.FindGameObjectWithTag("line").GetComponent<LineRenderer>();
        spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>();

        selectingAnimations = _selecting.GetComponent<SelectingAnimations>();

        vcam = GameObject.FindGameObjectWithTag("cam1").GetComponent<CinemachineVirtualCamera>();
        targetCam = GameObject.FindGameObjectWithTag("cam4").GetComponent<CinemachineVirtualCamera>();
        transposer = targetCam.GetCinemachineComponent<CinemachineTransposer>();
        //cinemachinBrain
        cinemachineBrain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();
        talkColor = GameObject.FindGameObjectWithTag("talk").GetComponent<Image>();
        rectTransform2 = transform.GetComponent<RectTransform>();


        if (targetCam == null)
        {
            Debug.Log("targetcam is null");
        }
        Debug.Log("rectransform2" + rectTransform2);
    }
    private void Awake()
    {
        Init();
        rectTransform2 = (transform as RectTransform);


        transposer.m_FollowOffset.x = defaultOffsetX;
        transposer.m_FollowOffset.y = defaultOffsetY;
        transposer.m_FollowOffset.z = defaultOffsetZ;
        targetCam.m_Lens.OrthographicSize = defaultOrthographicSize;
        startHandPosition = clickHandGameObject.anchoredPosition;
    }
    private void Start()
    {

        if (targetCam == null || transposer == null)
        {
            Debug.Log("did not cam1");
            return;
        }
        if (lineRender != null)
        {
            Debug.Log("lineRender" + lineRender);
            lineRender.positionCount = 2;//line render between 2 object
        }
        if (lineRender == null)
        {
            Debug.Log("linerender is njull");
        }
        if (spriteRenderer == null)
        {
            Debug.Log("did not get spriteRenderer");
        }

        if (canvas == null)
        {
            Debug.Log("did not find canvas");
        }
        if (_yushan.transform)
        {
            Debug.Log("yushan");
        }
    }
    private void Update()
    {
        Debug.Log("rec2" + rectTransform2);
        FindClosestEnemy();
        //FindDistance();
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 worldPoint = camera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hitInfo = Physics2D.Raycast(worldPoint, Vector2.zero);
            //Instantiate(_yushan, worldPoint, _yushan.rotation);
            if (hitInfo.collider != null)
            {
                Debug.Log("clicked" + hitInfo.collider);
                if (hitInfo.collider.tag == "npc")
                {
                    Debug.Log("npc" + hitInfo.collider.transform);

                    Debug.Log("distanceint" + distanceInt);
                    target = hitInfo.collider.gameObject.transform;
                    Debug.Log("select" + _selecting.GetComponents<RectTransform>().GetValue((int)_selecting.rect.x));
                    newPos2 = target.transform.position;
                    infomationPanel.gameObject.SetActive(true);
                    infomationPanel.anchoredPosition = new Vector2(target.transform.position.x, target.transform.position.y);
                    cam1.SetActive(false);
                    cam2.SetActive(false);
                    cam3.SetActive(false);
                    targetCam.gameObject.SetActive(true);
                    targetCam.m_Follow = target;
                    targetCam.m_Lens.OrthographicSize = selectedOrthographicSize;

                    Debug.Log("cam1 and targetcam" + cam1.activeInHierarchy +
                        "tarhetcam" + targetCam.gameObject.active);
                    transposer.m_FollowOffset.y = selectedOffsetY;
                    transposer.m_FollowOffset.x = selectedOffsetX;
                    transposer.m_FollowOffset.z = selectedOffsetZ;
                    //if (distanceInt <= 0)
                    //{

                    //    Debug.Log("npc finddistance" + hitInfo.collider.gameObject.transform);






                    //}

                    //if (target.transform.tag == "Player")
                    //{
                    //    Debug.Log("player");
                    //    return;
                    //}





                }
                if (hitInfo.collider.tag != "npc") ;
                {
                    Debug.Log("hitinfo.collider.tag" + hitInfo.collider.tag);
                    target = none;
                    //transposer.m_FollowOffset.x = defaultOffsetX;
                    //transposer.m_FollowOffset.y = defaultOffsetY;
                    //transposer.m_FollowOffset.z = defaultOffsetZ;
                    //cam1.m_Lens.OrthographicSize = defaultOrthographicSize;
                    vcam.gameObject.SetActive(false);
                    cam1.SetActive(false);
                    cam1.GetComponent<CinemachineVirtualCamera>().m_Follow = _yushan;
                    targetCam.gameObject.SetActive(true);
                    Debug.Log("cameraEngine update else" + target);
                }

            }


        }
        //if (Input.GetMouseButtonDown(0))
        //{

        //    Vector3 worldPoint = camera.ScreenToWorldPoint(Input.mousePosition);

        //    RaycastHit2D hitInfo = Physics2D.Raycast(worldPoint, Vector3.zero);
        //    Debug.Log("mouseclicked" + hitInfo.collider + "worldpoint" + worldPoint);
        //    Instantiate(_yushan, worldPoint, transform.rotation);

        //    if (hitInfo.collider != null)
        //    {
        //        Debug.Log("hitinfo is not null" + hitInfo.collider);

        //        Debug.Log("clicked" + hitInfo.collider.name);
        //        if (hitInfo.collider.tag == "npc")
        //        {
        //            Debug.Log("clicked npc");
        //            List<Transform> npcTransforms = new List<Transform>();
        //            npcTransforms.Add(hitInfo.collider.gameObject.transform);
        //            target = npcTransforms[0];
        //            _selecting.gameObject.transform.position = target.transform.position;
        //            selectingAnimations.Selecting();
        //            cam1.m_LookAt = target;
        //            //ui dialog information box pops up
        //            //code here
        //            transposer.m_FollowOffset.x = 0f; informationPanel.gameObject.SetActive(true);
        //            Vector3 newPos = new Vector3();
        //            informationPanel.transform.position = target.transform.position;

        //            Debug.Log("newpos" + newPos);





        //        }
        //        if (hitInfo.collider.tag == "exit")
        //        {

        //            if (cam1.isActiveAndEnabled == false)
        //            {
        //                Debug.Log("no cam 1");
        //                cam1.enabled = true;
        //                cam2.SetActive(false);
        //                cam3.SetActive(false);
        //            }
        //            Debug.Log("!= npc");
        //            target = null;
        //            cam1.m_Follow = _yushan;
        //            cam1.m_Lens.FieldOfView = defaultFieldOfView;
        //            transposer.m_FollowOffset.x = defaultOffsetX;
        //            transposer.m_FollowOffset.y = defaultOffsetY;
        //            informationPanel.SetActive(false);

        //        }

        //    }


        //}
    }

    public void SetDimensions(Vector2 position)
    {
        //RectTransform rt = infomationPanel.GetComponent<RectTransform>();
        //rt.anchoredPosition = position;
        //Debug.Log(position + " " + rt.anchoredPosition);
        //Debug.Log("rtposition" + position);
    }

    private void FindClosestEnemy()
    {
        float distanceToClosestNpc = Mathf.Infinity;



        _gameObj = GameObject.FindGameObjectsWithTag("npc");



        for (int i = 0; i < _gameObj.Length; i++)
        {
            _spriteRenderers = _gameObj[i].GetComponentsInChildren<SpriteRenderer>();
            Debug.Log("_gmeObjLenth" + _gameObj[i] + _gameObj.Length);
            for (int a = 0; a < _spriteRenderers.Length; a++)
            {
                float distanceToNpc = (_gameObj[i].transform.position - _yushan.transform.position).sqrMagnitude;


                if (distanceToNpc < distanceToClosestNpc)
                {
                    FindDistance();
                    distanceToClosestNpc = distanceToNpc;
                    closestNpc = _gameObj[i].transform;
                    distanceInt = (int)distanceToClosestNpc;

                    //distanceText.text = distanceToClosestNpc.ToString() + "M";

                    if (closestNpc.transform.position.y > _yushan.transform.position.y)
                    {
                        spriteRenderer.sortingOrder = 1;
                    }
                    if (closestNpc.transform.position.y < _yushan.transform.position.y)
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
                    Debug.Log("來到這邊了");
                    Vector2 newPos = closestNpc.transform.position;
                    rectTransform.anchoredPosition = new Vector2(newPos.x, newPos.y);

                    talkColor.color = new Color(255, 255, 255, 255);
                    Debug.Log("color" + talkColor.color + "recttransform anchoreposition" + rectTransform.anchoredPosition + "newPos" + newPos);
                    lineRender.SetPosition(0, new Vector3(closestNpc.transform.position.x, closestNpc.transform.position.y, 0f));
                    lineRender.SetPosition(1, new Vector3(_yushan.transform.position.x, _yushan.transform.position.y, 0f));



                    Debug.DrawLine(_yushan.transform.position, closestNpc.transform.position);
                }
                else
                {
                    talkColor.color = new Color(255, 255, 255, 0);
                }


            }
        }





    }

    private void FindDistance() // find distance based on yushan to which object you clicked
    {
        if (other)//other is yushan
        {
            Debug.Log("other" + other);
            if (closestNpc != null)
            {
                Debug.Log("closestNpc" + closestNpc);

                distance = Vector3.Distance(other.position, closestNpc.transform.position);


                distanceInt = (int)distance;

                distanceText.text = closestNpc.name.ToString() + ":" + distanceInt.ToString() + "M";
                if (distanceInt == 0)
                {
                    Vector2 newPos = closestNpc.transform.position;
                    talkColor.color = new Color(255, 255, 255, 255);
                    rectTransform.anchoredPosition = new Vector2(newPos.x, newPos.y);
                    distanceText.text = closestNpc.name.ToString() + ":" + distanceInt.ToString() + "M";
                    Debug.Log("distance == 0" + talkColor.color);
                }
                if (distanceInt >= 1)
                {

                    talkColor.color = new Color(255, 255, 255, 0);
                    distanceText.text = closestNpc.name.ToString() + ":" + distanceInt.ToString() + "M";
                    Debug.Log("distance > 1" + talkColor.color);
                }
            }
            else if (closestNpc == null)
            {
                distanceText.text = "there is no closetNpc";
            }

        }
    }

    private void OnMouseOver()
    {
        Debug.Log("onmouseover" + this.gameObject);

        if (this.gameObject.tag == "npc")
        {
            Debug.Log("over npc");
            selectingAnimations.Selecting();
        }
    }
    private void OnMouseExit()
    {

        Debug.Log("onmouseexit" + this.gameObject.tag);
        if (this.gameObject.tag == "npc")
        {
            Debug.Log("exit npc");
            selectingAnimations.NotSelect();
        }

    }
    public void ZoomOut()
    {
        Debug.Log("zoomout" + zoomOutClicks);

        if (zoomOut.tag == "zoom-out")
        {
            zoomOutClicks += 1;
            switch (clicks)
            {


                case 1:
                    cam2.SetActive(true);
                    cam1.SetActive(false);
                    cam3.SetActive(false);
                    break;

                default:
                    Debug.Log("clicks" + zoomOutClicks);
                    break;

            }
            if (zoomOutClicks == 1) zoomOutClicks = 0;
            Debug.Log("clicks" + zoomOutClicks);
        }



    }
    //public void ZoomOut()
    //{
    //    int zoomOutBackToZero = 0;
    //    zoomOutClickedTimes = 1;
    //    Debug.Log("zoonout");
    //    if (zoomOut.tag == "zoom-out" && zoomOutClickedTimes == 1)
    //    {
    //        isZoomIn = false;
    //        isZoomOut = true;
    //        zoomOutClickedTimes = 2;
    //        Debug.Log("clicked zoomout");
    //        if (isZoomOut == true && zoomOutClickedTimes == 2)
    //        {

    //            cam2.SetActive(false);
    //            cam1.enabled = true;
    //            cam3.SetActive(false);
    //            zoomOutClickedTimes = 3;
    //            Debug.Log("cam1 false");
    //            if (zoomOut.tag == "zoom-out" && zoomOutClickedTimes == 3)
    //            {
    //                Debug.Log("zoomoutclicked3" + zoomOutClickedTimes);
    //                cam1.enabled = false;
    //                cam2.SetActive(true);
    //                cam3.SetActive(false);
    //                zoomOutClickedTimes = 4;
    //                if (zoomOut.tag == "zoom-out" && zoomOutClickedTimes == 4)
    //                {
    //                    return;

    //                }
    //            }


    //        }

    //    }

    //}
    public void ZoomIn()
    {

        Debug.Log("zoomin" + clicks);

        if (zoomIn.tag == "zoom-in")
        {
            clicks += 1;
            switch (clicks)
            {
                case 1:
                    cam1.SetActive(false);
                    cam2.SetActive(false);
                    cam3.SetActive(true);
                    break;
                case 2:
                    cam1.SetActive(true);
                    cam2.SetActive(false);
                    cam3.SetActive(false);
                    break;
                default:
                    Debug.Log("default" + clicks);
                    break;
            }
            if (clicks == 2)
            {
                clicks = 0;
            }
            Debug.Log("clicks" + clicks);
        }


    }
    //public void ZoomIn()
    //{
    //    int backToZero = 0;
    //    zoomInClickedTimes = 1;
    //    Debug.Log("zoomoin");


    //    if (zoomIn.tag == "zoom-in" && zoomInClickedTimes == 1)
    //    {
    //        isZoomOut = false;
    //        isZoomIn = true;

    //        Debug.Log("zoomout clicked");
    //        zoomInClickedTimes = 2;
    //        if (isZoomIn == true && zoomInClickedTimes == 2)
    //        {

    //            cam1.enabled = false;
    //            cam2.SetActive(false);
    //            cam3.SetActive(true);
    //            zoomInClickedTimes = 2;
    //            Debug.Log("zoom our false");
    //            if (zoomIn.tag == "zoom-in" && zoomInClickedTimes == 2)
    //            {
    //                cam1.enabled = false;
    //                cam2.SetActive(false);
    //                cam3.SetActive(false);
    //                zoomInClickedTimes = 3;
    //                if (zoomIn.tag == "zoom-in" && zoomInClickedTimes == 3)
    //                {
    //                    cam1.enabled = true;
    //                    cam2.SetActive(false);
    //                    cam3.SetActive(false);
    //                    zoomInClickedTimes = 4;
    //                    if (zoomInClickedTimes == 4)
    //                    {
    //                        return;
    //                    }
    //                }
    //            }

    //        }
    //        else
    //        {
    //            Debug.Log("zoom out not work");
    //        }


    //    }
    //}




    void OnEnable()
    {
        StartCoroutine("UIcoroutine");
    }

    void OnDisable()
    {
        StopCoroutine("UIcoroutine");

        clickHandGameObject.anchoredPosition = new Vector2(_yushan.transform.position.x, _yushan.transform.position.y);
        holdingHandGameObject.anchoredPosition = new Vector2(_yushan.transform.position.x, _yushan.transform.position.y);

        clickHandGameObject.gameObject.SetActive(true);
        holdingHandGameObject.gameObject.SetActive(true);
    }

    private IEnumerator UIcoroutine()
    {

        clickHandGameObject.gameObject.SetActive(false);

        while (true)
        {
            yield return new WaitForSeconds(1f);
            clickHandGameObject.gameObject.SetActive(true);
            holdingHandGameObject.gameObject.SetActive(false);


            while (Vector2.Distance(clickHandGameObject.anchoredPosition, targetGameObject.transform.position) > 1f)
            {

                clickHandGameObject.anchoredPosition = Vector2.MoveTowards(clickHandGameObject.anchoredPosition, targetGameObject.transform.position, Time.deltaTime * speed);

                yield return new WaitForSeconds(0.02f);
            }

            clickHandGameObject.anchoredPosition = new Vector2(targetGameObject.transform.position.x, targetGameObject.transform.position.y);
            clickHandGameObject.gameObject.SetActive(false);
            holdingHandGameObject.anchoredPosition = new Vector2(targetGameObject.transform.position.x, targetGameObject.transform.position.y);
            holdingHandGameObject.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);

            clickHandGameObject.gameObject.SetActive(false);
            holdingHandGameObject.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);

            clickHandGameObject.anchoredPosition = startHandPosition;
            clickHandGameObject.gameObject.SetActive(false);
            holdingHandGameObject.anchoredPosition = startHandPosition;
            holdingHandGameObject.gameObject.SetActive(true);

        }

    }
}

