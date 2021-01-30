using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Cinemachine;
public abstract class Strangers : MonoBehaviour
{

    [SerializeField]
    protected Camera camera;

    [SerializeField]
    protected CinemachineVirtualCamera cam1;
    [SerializeField]
    private Transform none;

    private void Init()
    {
        cam1 = GameObject.Find("cam1").GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        if (cam1 == null)
        {
            Debug.Log("did not cam1");
            return;
        }
    }

    public virtual void Update()
    {

        // mouse down select target and have canvas menu show up and camera zoom in
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hitInfo.collider != null)
            {
                Debug.Log("hitinfo.collider.name" + hitInfo.collider.name);
                if (hitInfo.collider.tag == "npc")
                {
                    Transform target = null;
                    Debug.Log("clicked npc" + hitInfo.collider.gameObject.transform);
                    target = hitInfo.collider.gameObject.transform;
                    cam1.m_Follow = none;
                    cam1.m_Follow = target;

                }
            }

        }
    }
    public virtual void move()
    {
        // let npc have raycast to determine distance
        // if distance have object npc will walk up and move forward again
        // if collid with object will have hit each other animation and fall back a little and move up or down
        // and keep move towards to its destination
    }













    //private void FindClosestEnemy()
    //{
    //    float distanceToClosestNpc = Mathf.Infinity;
    //    Transform centerPointNpc = null;
    //    Transform closestNpc = null;
    //    _spriteRen = new List<SpriteRenderer>();
    //    _gameObjList = new List<Transform>();
    //    _gameObj = GameObject.FindGameObjectsWithTag("npc");

    //    for (int i = 0; i < _gameObj.Length; i++)
    //    {

    //        SpriteRenderer renderer = _gameObj[i].GetComponentInChildren<SpriteRenderer>();
    //        Transform game = _gameObj[i].transform;
    //        if (game)
    //        {
    //            Debug.Log("game" + game);
    //            _gameObjList.Add(game);
    //            Debug.Log("gameobjectlist" + _gameObjList);
    //        }
    //        if (renderer)
    //        {
    //            Debug.Log("render" + renderer + _spriteRen);
    //            _spriteRen.Add(renderer);
    //        }
    //        if (_gameObj[i].transform.name == this.transform.name)
    //        {
    //            centerPointNpc = this.transform;
    //            _gameObjList.Remove(centerPointNpc);
    //            Debug.Log("remove List gameobjects" + _gameObjList + "centerpointnpc" + centerPointNpc);
    //        }
    //        float distanceToNpc = (game.position - centerPointNpc.position).sqrMagnitude;

    //        if (distanceToNpc < distanceToClosestNpc)
    //        {

    //            distanceToClosestNpc = distanceToNpc;
    //            closestNpc = ;

    //            if (closestNpc.transform.position.y > centerPointNpc.transform.position.y)
    //            {
    //                _spriteRen.sortingOrder = 1;
    //            }
    //            if (closestNpc.transform.position.y < centerPointNpc.transform.position.y)
    //            {
    //                spriteRenderer.sortingOrder = -1;
    //            }

    //        }
    //    }
    //    {

    //    }

    //    Debug.DrawLine(this.transform.position, closestNpc.transform.position);

    //}

}
