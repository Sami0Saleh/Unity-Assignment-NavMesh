using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Transform Player1;
    [SerializeField] Transform Player2;
    
    private void Update()
    {
        if (Player1.position.x < Player2.position.x)
        {
            camera.transform.SetParent(Player1.transform, true);
            camera.transform.rotation = Player1.rotation;
        }
        else if (Player2.position.x < Player1.position.x)
        {
            camera.transform.SetParent(Player2.transform, true);
            camera.transform.rotation = Player2.rotation;
        }
    }
}
