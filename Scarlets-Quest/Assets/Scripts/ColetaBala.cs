using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaBala : MonoBehaviour
{
    public int bulletCountValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.UpdateScore(bulletCountValue);
            GameController.instance.PlayBulletSound();
            Destroy(gameObject);
        }
    }

}