using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChange : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
    //[SerializeField]
    //private LayerMask _collisionLayer;
    //void Init()
    //{
    //    spriteRenderer = GameObject.FindGameObjectWithTag("sprite").GetComponent<SpriteRenderer>();
    //}
    //void Start()
    //{
    //    Init();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    RaycastHit2D hitRay = Physics2D.Raycast(transform.position, Vector2.right, 1.7f, _collisionLayer);
    //    Debug.DrawRay(transform.position, Vector2.right * 1.7f, Color.red);
    //    if (hitRay != null)
    //    {
    //        Debug.Log("hitray" + hitRay);
    //    }
    //    YushanAbility hit = collision.GetComponent<YushanAbility>();
    //    if (hit != null)
    //    {
    //        Debug.Log("hit yushanbility" + hit);
    //        Debug.Log(collision.tag + "collision");
    //        Debug.Log(collision.transform.GetComponent<BoxCollider2D>().tag + transform.GetComponent<BoxCollider2D>().tag);

    //        //Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    //        if (collision.tag == "collision")
    //        {






    //            if (collision.transform.GetComponent<BoxCollider2D>().offset.y <= transform.GetComponent<BoxCollider2D>().offset.y)
    //            {
    //                Debug.Log("sorting" + spriteRenderer.sortingOrder + "" + collision.transform.GetComponentInChildren<SpriteRenderer>().sortingOrder);
    //                spriteRenderer.sortingOrder -= 1;

    //            }
    //            if (collision.transform.GetComponent<BoxCollider2D>().offset.y >= transform.GetComponent<BoxCollider2D>().offset.y)
    //            {
    //                if (collision.transform.GetComponentInChildren<SpriteRenderer>().sortingOrder >= spriteRenderer.sortingOrder)
    //                {
    //                    Debug.Log(hit + "bigger than" + transform);

    //                    Debug.Log("i am here");
    //                    spriteRenderer.sortingOrder += 1;
    //                }

    //            }
    //            else if (collision.tag == "Player")
    //            {
    //                Debug.Log("Player return");
    //                return;
    //            }
    //        }
    //    }

    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("exitenter");
    //    spriteRenderer.sortingOrder = 0;
    //}
}
