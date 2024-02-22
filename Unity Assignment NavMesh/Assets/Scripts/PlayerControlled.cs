using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControlled : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] pathWaypoints;
    private Vector3 PlayerClick;
    private bool hasMoved = false;

    private void Start()
    {
        navMeshAgent.autoTraverseOffMeshLink = false;
    }
    void Update()
    {
        if (!navMeshAgent.isStopped && hasMoved)
        {
            if (PlayerClick != navMeshAgent.destination)
            {
                navMeshAgent.SetDestination(PlayerClick); 
            }

        }
        if (Input.GetMouseButton(0))
        {
            hasMoved = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                PlayerClick = hit.point;
            pathWaypoints[0].position = PlayerClick;
        }
        
    }
   
    
}
