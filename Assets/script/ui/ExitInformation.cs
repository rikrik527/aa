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
    private CinemachineTransposer transposer;
    //cam1
    [SerializeField]
    private CinemachineVirtualCamera cam1;
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
        transposer = cam1.GetCinemachineComponent<CinemachineTransposer>();
        _selectingAnimations = GameObject.FindGameObjectWithTag("select").GetComponent<SelectingAnimations>();
    }
    private void Awake()
    {
        Init();

    }
    public void Exit()
    {
        informationPanel.SetActive(false);
        CameraEngine.target = null;
        cam1.m_Follow = _yushan;
        cam1.m_Lens.FieldOfView = CameraEngine.defaultFieldOfView;
        transposer.m_FollowOffset.x = CameraEngine.defaultOffsetX;
        transposer.m_FollowOffset.y = CameraEngine.defaultOffsetY;
        transposer.m_FollowOffset.z = CameraEngine.defaultOffsetZ;
        if (cam1.isActiveAndEnabled == false)
        {
            Debug.Log("cam1.isactiveandenabled == false");
            cam1.enabled = true;
            cam2.SetActive(false);
            cam3.SetActive(false);
        }
    }


}
