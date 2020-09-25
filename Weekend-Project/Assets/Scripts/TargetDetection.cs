﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetDetection : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float speed = 1f;
    public float minDistance = 1f;
    public float maxDistance = 10f;
    public int damage = 1;
    public MobController mobController;

    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    private bool attackPossible = true;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        minDistance = minDistance + agent.radius;
        agent.stoppingDistance = minDistance;
        mobController = gameObject.GetComponent<MobController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = new Ray(transform.position, transform.forward * minDistance);
        Debug.DrawRay(transform.position, transform.forward * minDistance, Color.green);
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
            HitTarget(damage);
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

    // Walk random.
    void WalkRandom()
    {

    }

    // Do damage to a target.
    void HitTarget(int damage)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit) && mobController.HP > 0)
        {
            if (hit.distance <= minDistance && attackPossible == true)
            {
                attackPossible = false;
                Debug.Log("HIT!");
                animator.SetTrigger("hit");
                hit.transform.gameObject.SendMessage("GetDamage", damage, SendMessageOptions.DontRequireReceiver);
                StartCoroutine(wait(animator.GetCurrentAnimatorStateInfo(0).length));
            }
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        attackPossible = true;
        animator.ResetTrigger("hit");
        animator.Play("Idle");
    }
}
