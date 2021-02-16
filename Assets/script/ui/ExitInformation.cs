using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class ExitInformation : MonoBehaviour
{
    private static ExitInformation exitInfo;

    public static ExitInformation ExitInfo
    {
        get
        {
            if (exitInfo != null)
            {
                Debug.Log("exit" + exitInfo);
                throw new System.Exception();
            }
            return exitInfo;
        }
    }
    [SerializeField]
    private Canvas canvas;

    public GameObject informationPanel;
    private Button _exit;

    private SelectingAnimations _selectingAnimations;
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

    private CinemachineCameraOffset camraOffset;


    private void Init()
    {
        targetCam = GameObject.FindGameObjectWithTag("cam4").GetComponent<CinemachineVirtualCamera>();

        _selectingAnimations = GameObject.FindGameObjectWithTag("select").GetComponent<SelectingAnimations>();
    }
    private void Awake()
    {
        Init();

    }
    public void Exit()
    {
        informationPanel.SetActive(false);

        targetCam.m_Follow = null;
        targetCam.m_Lens.OrthographicSize = CameraEngine.defaultFieldOfView;
        transposer.m_FollowOffset.x = CameraEngine.defaultOffsetX;
        transposer.m_FollowOffset.y = CameraEngine.defaultOffsetY;
        transposer.m_FollowOffset.z = CameraEngine.defaultOffsetZ;
        if (targetCam.isActiveAndEnabled == false)
        {
            Debug.Log("cam1.isactiveandenabled == false");
            targetCam.enabled = true;
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
        }
    }


}
