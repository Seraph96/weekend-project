using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = .1f;
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(dirX, 0, dirZ);

        transform.position += moveDir * speed;
    }
}