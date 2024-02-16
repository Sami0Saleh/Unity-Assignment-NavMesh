using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class IlanCharacterController : MonoBehaviour
{
    private const int mudAreaID = 3;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] pathWaypoints;
    [SerializeField] TextMeshProUGUI Text;

    private int currentWaypointIndex = 0;
    private void Start()
    {
        navMeshAgent.SetDestination(pathWaypoints[currentWaypointIndex].position);
    }

    private void Update()
    {
        if (!navMeshAgent.isStopped && navMeshAgent.remainingDistance <= 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= pathWaypoints.Length)
                currentWaypointIndex = 0;
            navMeshAgent.SetDestination(pathWaypoints[currentWaypointIndex].position);
        }
        if (transform.position.x <= -70.03)
        {
            switch (this.tag)
            {
                case "red": { Text.color = Color.red; break; }
                case "blue": { Text.color = Color.blue; break; }
                case "yellow": { Text.color = Color.yellow; break; }

                default: break;
            }
            Text.text = $"{this.tag} Won";
            Text.text = $"{this.tag} Won";
            Time.timeScale = 0f;
        }
    
     
    }
    

    
}