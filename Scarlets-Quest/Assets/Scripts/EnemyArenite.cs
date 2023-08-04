using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArenite : MonoBehaviour
{
    public float TimeToAttack;
    public GameObject fire2;
    public Transform Firepoint;

    
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating(nameof(Attack), TimeToAttack, TimeToAttack);
    }

    void Attack()
    {
        Instantiate(fire2, Firepoint.position , Quaternion.identity);

    }
}
