using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class ExitInformation : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject informationPanel;
    private Button _exit;

    private SelectingAnimations _selectingAnimations;
    [SerializeField]
    private CinemachineVirtualCamera targetCam;
    private CinemachineTransposer transposer;
    //cam1
    [SerializeField]
    private GameObject cam1;
    [SerializeField]
    private GameObject cam2;
    [SerializeField]
    private GameObject cam3;
    //yushan
    [SerializeField]
    private Transform _yushan;
    public CameraEngine cameraEnine;
    private CinemachineCameraOffset camraOffset;

    //rect trasform informationpanel
    [SerializeField]
    private RectTransform recInfoMation;



    private void Init()
    {
        targetCam = GameObject.FindGameObjectWithTag("cam4").GetComponent<CinemachineVirtualCamera>();
        transposer = targetCam.GetCinemachineComponent<CinemachineTransposer>();
        _selectingAnimations = GameObject.FindGameObjectWithTag("select").GetComponent<SelectingAnimations>();

        if (informationPanel != null)
        {

            recInfoMation.localScale = new Vector3(0f, 0f, 1f);



        }

    }
    private void Awake()
    {


        Init();

    }
    public void Exit()
    {
        if (transposer == null)
        {
            Debug.Log("]nukll");
        }
        targetCam.m_Follow = null;
        if (transposer == null)
        {
            Debug.Log("transdposer ==  nukll");
        }
        targetCam.m_Lens.OrthographicSize = SingletonDefaultCamera.defaultOrthographicSize;
        Debug.Log("transposer" + transposer);
        transposer.m_FollowOffset.x = SingletonDefaultCamera.defaultOffsetX;
        transposer.m_FollowOffset.y = SingletonDefaultCamera.defaultOffsetY;
        transposer.m_FollowOffset.z = SingletonDefaultCamera.defaultOffsetZ;
        cam1.SetActive(true);
        targetCam.gameObject.SetActive(false);




        recInfoMation.localScale = new Vector3(0f, 0f, 1f);
        recInfoMation.gameObject.SetActive(false);





    }


}
