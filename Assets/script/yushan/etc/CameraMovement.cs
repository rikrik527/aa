using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;
public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    CinemachineBrain cinemachineBrain;
    [SerializeField]
    private GameObject gameObj;
    [SerializeField]
    private GameObject gameObject2;

    private Vector3 dragOrigin;
    private Vector3 touchOrigin;







    [SerializeField]
    private GameObject zoomIn;
    [SerializeField]
    private GameObject zoomOut;
    private void Start()
    {
        cinemachineBrain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();


    }







    private void Update()
    {

        //PanCamera();


    }
    //private void PanCamera()
    //{

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("mouseclicked1once");


    //        dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);


    //    }

    //    if (Input.GetMouseButton(0))
    //    {

    //        Vector3 diffrence2 = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

    //        cam.transform.position += diffrence2;


    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {

    //        Debug.Log("mouseup");

    //    }


    //        if (Input.touchCount > 0)
    //        {
    //            Touch touch = Input.GetTouch(0);





    //}
    //if (Input.touchCount > 1)
    //{
    //    Touch touch2 = Input.GetTouch(1);
    //    Vector3 diffrence = touchOrigin - cam.ScreenToWorldPoint(touch2.position);

    //    cam.transform.position += diffrence;


    //}
    //if (Input.touchCount < 0)
    //{

    //}



    //    }
    public void ZoomOut()
    {
        Debug.Log("zoonout");
        if (zoomOut.tag == "zoom-out")
        {
            Debug.Log("clicked zoomout");
            if (gameObject2.active == false)
            {

                gameObject2.SetActive(true);
                gameObj.SetActive(false);
                Debug.Log("gameobj false");
            }
            else
            {
                Debug.Log("zoomin not work");
            }
        }

    }
    public void ZoomIn()
    {
        Debug.Log("zoomoin");
        if (zoomIn.tag == "zoom-in")
        {
            Debug.Log("zoomout clicked");
            if (gameObj.active == false)
            {
                gameObj.SetActive(true);
                gameObject2.SetActive(false);
                Debug.Log("zoom our false");


            }
            else
            {
                Debug.Log("zoom out not work");
            }
        }
    }
}