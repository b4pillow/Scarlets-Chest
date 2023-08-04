using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedf;
    public int damage;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }

        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(speedf * Time.deltaTime * Vector2.left);
        
    }
}
