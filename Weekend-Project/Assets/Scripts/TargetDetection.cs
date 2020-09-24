using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetDetection : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float speed = 1f;
    public float minDistance = 1f;
    public float maxDistance = 10f;

    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = minDistance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }

    private void LateUpdate()
    {
        Vector3 distance = player.position - transform.position;
        if (distance.magnitude > minDistance && distance.magnitude < maxDistance)
        {
            RotateToTarget(player.position);
            WalkToTarget(player.position);
        }
        else if (distance.magnitude < minDistance)
        {
            StopWalking();
            RotateToTarget(player.position);
        }
        else
        {
            StopWalking();
            Debug.Log("NIEMAND DA!");
        }
    }

    // GameObject turns to target.
    void RotateToTarget(Vector3 targetPosition)
    {
        Quaternion destRotation;
        Vector3 relativePosition;

        Vector3 trp;
        trp = transform.position;
        trp.y = 0;
        targetPosition.y = 0;
        relativePosition = targetPosition - trp;

        destRotation = Quaternion.LookRotation(relativePosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, destRotation, rotationSpeed * Time.deltaTime);
    }

    // GameObject walks to target.
    void WalkToTarget(Vector3 targetPosition)
    {
        animator.SetBool("move", true);
        agent.destination = targetPosition;
        //GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward).normalized * speed;
    }

    // GameObject stops walking.
    void StopWalking()
    {
        animator.SetBool("move", false);
        agent.destination = transform.position;
    }
}
