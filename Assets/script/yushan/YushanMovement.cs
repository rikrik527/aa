using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YushanMovement : YushanBasics
{




    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }





    //[SerializeField]
    //private LayerMask _groundLayer;
    //[SerializeField]
    //private float _speed;
    //[SerializeField]
    //private float _JumpForce;
    //private bool _grounded = false;
    //private bool _resetJump = false;

    //private float move;

    //private SpriteRenderer _spriteRender;
    //private SpriteRenderer _spriteEffect;
    //private PlayerAnimations _playerAnim;
    //private Rigidbody2D _ridgi;

    //void Awake()
    //{
    //    _ridgi = GetComponent<Rigidbody2D>();
    //    _playerAnim = GetComponent<PlayerAnimations>();
    //    _spriteRender = GetComponentInChildren<SpriteRenderer>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Movement();
    //    if(Input.GetMouseButton(0) && IsGrounded() == true){
    //       return;
    //    }
    //}
    //void Movement()
    //{
    //    move = Input.GetAxisRaw("Horizontal");
    //    _grounded = IsGrounded();
    //    Flip();

    //    if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()== true)
    //    {
    //        Debug.Log("jump");

    //        _ridgi.velocity = new Vector2(_ridgi.velocity.x, _JumpForce);

    //        StartCoroutine(ResetJumpRoutine());
    //    }
    //    _ridgi.velocity = new Vector2(move * _speed, _ridgi.velocity.y);
    //    _playerAnim.Move(move);
    //}
    //bool IsGrounded()
    //{
    //    RaycastHit2D hitInfo =  Physics2D.Raycast(transform.position, Vector2.down,1f, _groundLayer);
    //    Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);
    //    Debug.Log(hitInfo);

    //    if (hitInfo != null)

    //    {
    //        if(_resetJump == false)
    //        {


    //            return true;
    //        }
    //    }
    //    return false;
    //}
    //void Flip()
    //{
    //    if(move > 0)
    //    {
    //        _spriteRender.flipX = false;





    //        }
    //    if(move < 0)
    //    {
    //        _spriteRender.flipX = true;




    //    }

    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    int back = 32;
    //    Debug.Log("collision!!");

    //    if (collision.collider.gameObject.name == "stranger")
    //    {
    //        Debug.Log("yushan" + collision.collider.gameObject.name);
    //        _spriteRender.sortingOrder = 37;


    //        if(collision.collider.tag == "stranger")
    //        {

    //            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //            _spriteRender.sortingOrder = 37;
    //            Debug.Log("ignore coliision" + _spriteRender.sortingOrder);
    //        }

    //    }
    //    if (collision.collider.gameObject.name == null)
    //    {
    //        Debug.Log("do nothing");
    //        return;
    //    }
    //    else if (collision.collider.gameObject.name != "stranger")
    //    {
    //        Debug.Log("collision" + collision.collider.gameObject.name);
    //        _spriteRender.sortingOrder = back;
    //        Debug.Log("not yushan" + _spriteRender.sortingOrder);
    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("triggerenter");
    //    if (other.gameObject.tag == "stranger")
    //    {
    //        Debug.Log("onentertrigger");
    //        _playerAnim.collisionFall();
    //    }
    //}

    //IEnumerator ResetJumpRoutine()
    //    {
    //        _resetJump = true;
    //        yield return new WaitForSeconds(3f);
    //        _resetJump = false;
    //    }
}
