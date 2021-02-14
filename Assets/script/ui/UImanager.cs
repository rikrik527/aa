using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{

    private static UImanager _instance;

    public static UImanager Instance
    {
        get
        {
            if (_instance != null)
            {
                throw new System.Exception();
            }
            return _instance;
        }
    }

    public Button _actions, _punch, _cry, _command, _run;
    public PlayerAnimations _playerAnims;
    public CameraEngine cameraEngine;
    public Animator animator;
    private void Init()
    {
        cameraEngine = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraEngine>();
        _playerAnims = GameObject.FindGameObjectWithTag("players").GetComponentInChildren<PlayerAnimations>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();

    }
    private void Awake()
    {
        Init();
        Debug.Log("_instance = this" + _instance);
        if (_playerAnims == null)
        {
            Debug.Log("error");
        }
        if (cameraEngine == null)
        {
            Debug.Log("cameraEngine not found");
            throw new System.Exception();
        }
        if (animator == null)
        {

            Debug.Log("animator not found");
            throw new System.Exception();
        }

        _instance = this;
    }
    private void Update()
    {

    }
    public void Actions()
    {
        return;
    }
    public void Punch()
    {
        return;
    }

    public void Cry()
    {

        _playerAnims.SitOnGround();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("sit-on-ground"))
        {
            return;
        }
        else
        {
            _playerAnims.Cry();
        }



    }
    public void StopCry()
    {
        _playerAnims.StopCry();
    }
    public void Run()
    {
        _playerAnims.Run();
    }

}
