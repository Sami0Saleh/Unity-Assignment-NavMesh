using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControlled : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] pathWaypoints;
    [SerializeField] TextMeshProUGUI Text;
    private Vector3 PlayerClick;
    private bool hasMoved = false;
    
    void Update()
    {
        if (!navMeshAgent.isStopped && hasMoved)
        {
            if (PlayerClick != navMeshAgent.destination)
            {
                navMeshAgent.SetDestination(PlayerClick); 
            }

        }
        if (transform.position.x <= -70.03)
        {
            Text.text = $"{this.tag} Won";
            Time.timeScale = 0f;
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
            Time.timeScale = 0f;
        }
    }
}
