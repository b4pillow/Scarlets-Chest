using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaBala : MonoBehaviour
{
    public int bulletCountValue;
    //valor de quanto cada bala vale na contagem de balas
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.UpdateScore(bulletCountValue);
            Destroy(gameObject);
        }
    }
}