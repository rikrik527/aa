using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerUpAndDown : MonoBehaviour //put it in yushan
{
    private new Transform transform; //yushan transform
    private GameObject[] _gameObj;
    private Transform[] _trans;
    private SpriteRenderer spriteRenderer;
    private GameObject[] target = null;
    private Transform other;
    private void Start()
    {
        transform = GetComponent<Transform>();//get yushan
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //_gameObj = GameObject.FindGameObjectsWithTag("npc");
        //foreach (GameObject go in _gameObj)
        //{
        //    Debug.Log("_____" + _gameObj + "00000" + go);
        //}
        //Debug.Log("transform" + transform);
    }





    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Transform closestEnemy = null;
        _gameObj = GameObject.FindGameObjectsWithTag("npc");

        for (int i = 0; i < _gameObj.Length; i++)
        {
            float distanceToEnemy = (_gameObj[i].transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = _gameObj[i].transform;
                if (closestEnemy.transform.position.y > this.transform.position.y)
                {
                    spriteRenderer.sortingOrder = 1;
                }
                if (closestEnemy.transform.position.y < this.transform.position.y)
                {
                    spriteRenderer.sortingOrder = -1;
                }

            }
        }
        {

        }

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
    }

}
