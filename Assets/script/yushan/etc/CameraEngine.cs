using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class CameraEngine : MonoBehaviour
{
    [SerializeField]
    private Camera camera;//set camera to main camera

    [SerializeField]
    private CinemachineVirtualCamera cam1;//set vcam to cam1
    private CinemachineTransposer transposer;
    [SerializeField]
    private Transform none;//set m follow to none
    [SerializeField]
    private Transform _yushan;//yushan

    [SerializeField]
    private Transform other;
    [SerializeField]
    private Transform target;
    public static GameObject controlledUnit = null;
    [SerializeField]
    private Text distanceText;

    public static float distance;
    public static int distanceInt;

    //outline near 0+m
    [SerializeField]
    private Material material;// mouse click spriterenderer turned to outline

    // default camera orthographic size
    private float defaultOrthoGraphicSize = 3.43f;
    // default camera offset x
    private float defaultOffsetX = 2.64f;
    private void Init()
    {




        cam1 = GameObject.Find("cam1").GetComponent<CinemachineVirtualCamera>();
        transposer = cam1.GetCinemachineComponent<CinemachineTransposer>();
    }
    private void Start()
    {
        Init();
        if (cam1 == null || transposer == null)
        {
            Debug.Log("did not cam1");
            return;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 worldPoint = camera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hitInfo = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hitInfo.collider != null)
            {
                Debug.Log("clicked");
                if (hitInfo.collider.tag == "npc")
                {
                    Debug.Log("npc" + hitInfo.collider.transform);
                    FindDistance();
                    Debug.Log("distanceint" + distanceInt);
                    target = hitInfo.collider.gameObject.transform;
                    cam1.m_Follow = none;
                    cam1.m_Follow = target;
                    cam1.m_Lens.OrthographicSize = 1.8f;


                    transposer.m_FollowOffset.x = 0;
                    //if (distanceInt <= 0)
                    //{

                    //    Debug.Log("npc finddistance" + hitInfo.collider.gameObject.transform);






                    //}

                    //if (target.transform.tag == "Player")
                    //{
                    //    Debug.Log("player");
                    //    return;
                    //}
                    if (distanceInt > 1)
                    {
                        Debug.Log("bigger than 1");

                        Debug.Log("else on cameraengine");
                        cam1.m_Follow = none;
                        cam1.m_Follow = _yushan;
                        cam1.m_Lens.OrthographicSize = defaultOrthoGraphicSize;
                        transposer.m_FollowOffset.x = defaultOffsetX;
                    }




                }

            }
            else
            {
                Debug.Log("cameraEngine update else");
            }

        }
    }
    private void FindDistance()
    {
        if (other)
        {
            Debug.Log("other" + other);
            if (target != null)
            {
                Debug.Log("target" + target);

                distance = Vector3.Distance(other.position, target.position);

                Debug.Log("dist" + distance + "other" + other + "transform" + transform);

            }
            distanceInt = (int)distance;

            distanceText.text = target + ":" + distanceInt.ToString() + "M";
        }
    }
    public void CenterCameraPosition()
    {
        cam1.m_Lens.OrthographicSize = 4.44f;
        transposer.m_FollowOffset.x = 0f;
    }
}

