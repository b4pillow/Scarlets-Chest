using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform _player;
    public float suave;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 following = new Vector3(_player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, following, suave * Time.deltaTime);
    }
}
