using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offsetX = -5;
    public float offsetZ = 0;
    public float offsetY = 0;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3 ((player.transform.position.x + offsetX), (player.transform.position.y + offsetY), (player.transform.position.z + offsetZ));
    }
} 
