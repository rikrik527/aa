using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SwitchBoundingShape()
    {
        //get the polygon collider on the boundsconfiner gameobject which is used by cinemachine to prevent the camera going beyond the screen edges
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BOUNDING_CONFINER).GetComponent<PolygonCollider2D>();
        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
        //since the confiner bounds have changed need to call this to clear the cache
        cinemachineConfiner.InvalidatePathCache();
        Debug.Log("switchboundingshape");
    }
}
