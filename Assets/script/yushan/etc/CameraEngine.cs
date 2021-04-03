using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Linq;
using System;
using UnityEngine.EventSystems;

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
    private CinemachineFramingTransposer transposer;

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
    private GameObject CloseUpView;

    [SerializeField]
    private GameObject CityView;

    [SerializeField]
    private GameObject DefaultView;

    [SerializeField]
    private Text distanceText;


    public static float distance;
    public static int distanceInt;


    //outline near 0+m
    [SerializeField]
    private Material material;// mouse click spriterenderer turned to outline







    //clicked on npc
    private bool clickedOnNpc;














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


    //static canvas talk option
    public RectTransform rectTransform;
    public static Image talkColor;

    //infomationpanel
    [SerializeField]
    private RectTransform infomationPanel;


    private void Init()
    {
        //findclosetenemy getcomponent
        lineRender = GameObject.FindGameObjectWithTag("line").GetComponent<LineRenderer>();
        spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>();

        selectingAnimations = _selecting.GetComponent<SelectingAnimations>();

        vcam = GameObject.FindGameObjectWithTag("cam1").GetComponent<CinemachineVirtualCamera>();
        //targetCam = GameObject.FindGameObjectWithTag("cam4").GetComponent<CinemachineVirtualCamera>();
        transposer = targetCam.GetComponentInChildren<CinemachineFramingTransposer>();
        //cinemachinBrain
        cinemachineBrain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();




        if (targetCam == null)
        {
            Debug.Log("targetcam is null");
        }
        if (transposer == null)
        {
            Debug.Log("null trasposer");
        }

    }
    private void Awake()
    {

        Init();



        transposer.m_TrackedObjectOffset.x = SingletonDefaultCamera.defaultOffsetX;
        transposer.m_TrackedObjectOffset.y = SingletonDefaultCamera.defaultOffsetY;
        transposer.m_TrackedObjectOffset.z = SingletonDefaultCamera.defaultOffsetZ;
        targetCam.m_Lens.OrthographicSize = SingletonDefaultCamera.defaultOrthographicSize;

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
        Physics2D.queriesHitTriggers = false;
        FindClosestEnemy();
    }
    private void FixedUpdate()
    {

        Physics2D.queriesHitTriggers = true;
        //FindDistance();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clickedonnpc" + clickedOnNpc);
            Vector2 worldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 screenPos = camera.WorldToScreenPoint((Vector3)spriteRenderer.transform.position);
            var canvas = GameObject.Find("Canvas");
            RaycastHit2D hitInfo = Physics2D.Raycast(worldPoint, Vector2.zero);
            //Instantiate(_yushan, worldPoint, _yushan.rotation);

            if (hitInfo.collider != null)
            {
                Debug.Log("clicked" + hitInfo.collider);
                if (hitInfo.collider.tag == "npc")
                {
                    clickedOnNpc = true;
                    Debug.Log("npc" + hitInfo.collider.transform);

                    Debug.Log("distanceint" + distanceInt);
                    // disable change view while selecting character

                    CityView.SetActive(false);
                    DefaultView.SetActive(false);
                    CloseUpView.SetActive(false);
                    target = hitInfo.collider.gameObject.transform;
                    //Debug.Log("select" + _selecting.GetComponents<RectTransform>().GetValue((int)_selecting.rect.x));
                    selectingAnimations.Selecting();
                    _selecting.anchoredPosition = Vector3.zero;
                    infomationPanel.gameObject.SetActive(true);
                    //infomationPanel.anchoredPosition = Vector3.zero;

                    //cam1.SetActive(false);
                    //cam2.SetActive(false);
                    //cam3.SetActive(false);
                    targetCam.gameObject.SetActive(true);
                    targetCam.m_Follow = target;
                    targetCam.m_Lens.OrthographicSize = SingletonDefaultCamera.selectedOrthographicSize;

                    Debug.Log("cam1 and targetcam" + cam1.activeInHierarchy +
                        "tarhetcam" + targetCam.gameObject.active);
                    transposer.m_TrackedObjectOffset.y = SingletonDefaultCamera.selectedOffsetY;
                    transposer.m_TrackedObjectOffset.x = SingletonDefaultCamera.selectedOffsetX;
                    transposer.m_TrackedObjectOffset.z = SingletonDefaultCamera.selectedOffsetZ;
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



                    Debug.Log("來到這邊了");





                    lineRender.SetPosition(0, new Vector3(closestNpc.transform.position.x, closestNpc.transform.position.y, 0f));
                    lineRender.SetPosition(1, new Vector3(_yushan.transform.position.x, _yushan.transform.position.y, 0f));



                    Debug.DrawLine(_yushan.transform.position, closestNpc.transform.position);
                }
                else
                {
                    Debug.Log("ha");
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
                Vector2 newPos = closestNpc.transform.position;
                //distanceText.text = closestNpc.name.ToString() + ":" + distanceInt.ToString() + "M";

                if (distanceInt >= 3)
                {
                    distanceText.text = closestNpc.name.ToString() + ":" + distanceInt.ToString() + "M";

                    if (distanceInt == 0)
                    {

                        rectTransform.gameObject.SetActive(true);
                        //rectransform = cnavas text
                        rectTransform.anchoredPosition = new Vector2(newPos.x, newPos.y);
                        Vector2 recPos = rectTransform.anchoredPosition;
                        Debug.Log("finddistance text closenpc" + rectTransform.transform.position + closestNpc.transform.position);


                        distanceText.text = closestNpc.name.ToString() + ":" + distanceInt.ToString() + "M";
                        if (distanceInt >= 1)
                        {
                            rectTransform.gameObject.SetActive(false);
                        }

                    }
                }


                //if (distanceInt >= 1)
                //{
                //    distanceText.text = 

                //}
            }
            else if (closestNpc == null)
            {
                distanceText.text = "there is no closetNpc";
            }

        }
    }


    public void CityOfView()
    {
        Debug.Log("cityview cam2");

        if (CityView.tag == "city-view")
        {

            cam2.SetActive(true);
            cam1.SetActive(false);
            cam3.SetActive(false);
            targetCam.gameObject.SetActive(false);

        }

    }


    public void OnMouseEnter(BaseEventData data)
    {
        PointerEventData p = data as PointerEventData;
        Debug.Log("Enter Position : " + p.position);
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
    public void DefaultOfView()
    {



        if (DefaultView.tag == "default-view")

            cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        targetCam.gameObject.SetActive(false);


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


    public void CloseUpOfView()
    {
        if (CloseUpView.tag == "closeup-view")
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            targetCam.gameObject.SetActive(false);
        }
    }


}

