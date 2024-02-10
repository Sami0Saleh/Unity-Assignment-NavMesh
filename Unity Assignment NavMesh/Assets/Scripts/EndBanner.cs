using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBanner : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "red")
        {
            Debug.Log("Red Won");
        }
        else if (collision.gameObject.name == "blue")
        {
            Debug.Log("Blue Won");
        }
    }
}