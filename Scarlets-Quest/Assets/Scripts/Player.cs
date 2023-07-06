using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool _isJumping;

    private Rigidbody2D _rig;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        _rig.velocity = new Vector2(movement * speed, _rig.velocity.y);

        if (movement > 0 && !_isJumping)
        {
            _anim.SetInteger("transition",1);
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if (movement < 0 && !_isJumping)
        {
            _anim.SetInteger("transition",1);
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if (movement == 0 && !_isJumping)
        {
            _anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(!_isJumping)
            {
                _anim.SetInteger("transition", 2);
                _rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                _isJumping = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 6)
        {
            _isJumping = false;
        }

    }
}