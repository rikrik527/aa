using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Blocks : MonoBehaviour
{
    private PolygonCollider2D polygon;
    private BoxCollider2D playerBox;
    private GameObject[] npcObj;
    private BoxCollider2D npcBox;
    public virtual void Start()
    {
        polygon = GetComponent<PolygonCollider2D>();
        playerBox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        npcObj = GameObject.FindGameObjectsWithTag("npc");



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int i = 0;
        for (i = 0; i < npcObj.Length; i++)
        {
            Debug.Log("等著等著就老了" + npcObj[i].transform.GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(npcObj[i].transform.GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());

            Physics2D.IgnoreCollision(playerBox.transform.GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());
        }
    }
}
