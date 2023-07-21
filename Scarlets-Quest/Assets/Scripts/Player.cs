
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
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
    public int health = 3;
    private float movement;
    public float lookDirection;
    
    private AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        lookDirection = 1f;
            
        GameController.instance.UpdateLives(health);

        sound = GetComponent<AudioSource>();
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
        if (!_isShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            sound.Play();
            _isShoot = true;
            _anim.SetInteger("transition", 3);
            GameObject tiro = Instantiate(shoot, shootexit.position, shootexit.rotation);
            yield return new WaitForSeconds(0.5f);
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

        if (coll.gameObject.layer == 8)
        {
           GameController.instance.GameOver();
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);
        _anim.SetTrigger("hit");
        
        if (health <= 0)
        {
            GameController.instance.GameOver();
         gameObject.SetActive(false);
         
        }

        if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
        
        if (transform.rotation.y == 180)
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }
    }

}