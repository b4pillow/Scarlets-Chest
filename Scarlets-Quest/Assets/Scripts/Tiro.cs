using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private Rigidbody2D _rig;
    public float speed;
    public int dmg = 2;

    public bool _isRight;
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isRight)
        {
            _rig.velocity = Vector2.right * speed;
        }
        else
        {
            _rig.velocity = Vector2.left * speed;
        }

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Espinho>()?.Morte(dmg);
            Destroy(gameObject);
        }
    }

    public void Setup(bool isRight)
    {
        _isRight = isRight;
    }
    
}
