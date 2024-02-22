using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class IlanCharacterController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] pathWaypoints;
    [SerializeField] private NavMeshLink Link;
    private int currentWaypointIndex = 0;
    private bool Jumping = false;
    private float jumpHeight = 2.0f;
    private float jumpDuration = 1f;
    private float timeElapsed = 0;
    private void Start()
    {
        navMeshAgent.SetDestination(pathWaypoints[currentWaypointIndex].position);
    }

    private void Update()
    {
        if (navMeshAgent.isOnOffMeshLink)
        {
            
         /*   Vector3 start = Link.startPoint;
            Vector3 end = Link.endPoint;

            if (timeElapsed < jumpDuration)
            {
                float t = timeElapsed / jumpDuration;
                navMeshAgent.transform.position = Vector3.Lerp(start, end, t) + jumpHeight * Vector3.up;
                timeElapsed += Time.deltaTime;
            }*/

            
        }
        if (!navMeshAgent.isStopped && navMeshAgent.remainingDistance <= 0.1f && Jumping == false)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= pathWaypoints.Length)
                currentWaypointIndex = 0;
            navMeshAgent.SetDestination(pathWaypoints[currentWaypointIndex].position);       
        }
    }




}