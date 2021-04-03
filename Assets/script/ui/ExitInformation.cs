using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System;

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
    private CinemachineFramingTransposer transposer;
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
    //view angle
    [SerializeField]
    private GameObject CloseUpView;

    [SerializeField]
    private GameObject CityView;

    [SerializeField]
    private GameObject DefaultView;



    private void Init()
    {

        transposer = targetCam.GetComponentInChildren<CinemachineFramingTransposer>();
        _selectingAnimations = GameObject.FindGameObjectWithTag("select").GetComponent<SelectingAnimations>();

        if (informationPanel != null)
        {
            Debug.Log("not null information");
            recInfoMation.anchoredPosition = Vector3.zero;



        }


    }
    private void Awake()
    {

        try
        {
            Init();
            Debug.Log("tried");
        }
        catch (Exception ex)
        {
            Debug.Log("ex" + ex.ToString());
        }


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


        targetCam.gameObject.SetActive(false);


        //targetCam.m_Lens.OrthographicSize = SingletonDefaultCamera.defaultOrthographicSize;
        //Debug.Log("transposer" + transposer);
        //transposer.m_FollowOffset.x = SingletonDefaultCamera.defaultOffsetX;
        //transposer.m_FollowOffset.y = SingletonDefaultCamera.defaultOffsetY;
        //transposer.m_FollowOffset.z = SingletonDefaultCamera.defaultOffsetZ;

        CityView.SetActive(true)
         ;
        DefaultView.SetActive(true)
;
        CloseUpView.SetActive(true)
;
        recInfoMation.gameObject.SetActive(false);
        _selectingAnimations.NotSelect();




    }


}
