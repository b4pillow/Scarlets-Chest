
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool _isJumping;
    private bool _isShoot;
    public GameObject shoot;
    public Transform shootexit;
    private Rigidbody2D _rig;
    private Animator _anim;

    private float movement;
    private float lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        BowFire();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        
        movement = Input.GetAxis("Horizontal");
        if (movement != 0)
        {
            lookDirection = movement;
        }
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

        if (movement == 0 && !_isJumping && !_isShoot)
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

    void BowFire()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isShoot = true;
            _anim.SetInteger("transition", 3);
            GameObject tiro = Instantiate(shoot, shootexit.position, shootexit.rotation);
            shoot.GetComponent<Tiro>().Setup(false);
            if (lookDirection > 0)
            {
                shoot.GetComponent<Tiro>().Setup(true);
            }

            if (lookDirection < 0)
            {
                
            }
            
            yield return new WaitForSeconds(0.2f);
            _isShoot = false;
            _anim.SetInteger("transition", 0);
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