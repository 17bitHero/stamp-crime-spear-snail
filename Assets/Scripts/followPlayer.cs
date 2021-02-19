using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float followSpeed;
    public Transform player;
    public Vector3 offsetLocation;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.position = new Vector3(player.position.x + offsetLocation.x, player.position.y + offsetLocation.y, player.position.z + offsetLocation.z);
        float step = followSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position + offsetLocation, step);
        //transform.position = new Vector3(0f, 0f, -10);
    }
}
