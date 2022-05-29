using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed = 2f;
    private Vector3 playerPosition;
    private float vertical, horizontal;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetZ;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //vertical = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>().Vertical();
        //horizontal = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>().Horizontal();
    }
    private void Update()
    {
        if (player)
        {
            playerPosition = new Vector3(player.transform.position.x + offsetX, player.transform.position.y+10, player.transform.position.z + offsetZ);
            Vector3 currentPosition = Vector3.Lerp(transform.position, playerPosition, speed * Time.deltaTime);
            transform.position = currentPosition;
            
        }
            //    if(vertical > 0.5f)
        //    {
        //        offsetX = 5; offsetZ = -5;
        //    }
        //    Debug.Log($"vertical = {vertical}, horizontal = {horizontal}");
        //}

    }
}
