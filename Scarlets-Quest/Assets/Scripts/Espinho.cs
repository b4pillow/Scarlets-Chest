using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour
{
    public float speed;
    public float walkTime;
    [SerializeField] int health;
    private float timer;
    private bool walkRight;
    public int damage = 1;

    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (walkTime == -1)
        {
            return;
        }

            if (timer >= walkTime)
            {
                walkRight = !walkRight;
                timer = 0f;
            }

            if (walkRight)
            {
                transform.eulerAngles = new Vector2(0, 180);
                rig.velocity = Vector2.right * speed;
            }

            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                rig.velocity = Vector2.left * speed;
            }
            
    }

    public void Morte(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
}
