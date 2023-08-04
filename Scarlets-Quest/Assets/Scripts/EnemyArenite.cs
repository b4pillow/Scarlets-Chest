using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArenite : MonoBehaviour
{
    public float TimeToAttack;
    public GameObject fire2;
    
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating(nameof(Attack), TimeToAttack, TimeToAttack);
    }

    void Attack()
    {
        Instantiate(fire2, transform.position + Vector3.left, Quaternion.identity);

    }
}
