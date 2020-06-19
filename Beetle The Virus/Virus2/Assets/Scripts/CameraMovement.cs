using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        offset = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, 0) + offset;
    }
}
