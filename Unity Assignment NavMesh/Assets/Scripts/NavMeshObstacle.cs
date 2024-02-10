using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshObstacle : MonoBehaviour
{
    public Vector3 StartingPos;
    public Vector3 EndingPos;
    public bool Direction = false;
    private float _speed;
    Vector3 MoveLeft = Vector3.left;
    Vector3 MoveRight = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        StartingPos = transform.position;
        _speed = Random.Range(3, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > EndingPos.z && Direction == false)
        { transform.Translate(MoveLeft * Time.deltaTime * _speed); }
        else if (transform.position.z <= EndingPos.z)
        { Direction = true; }
        if (transform.position.z < StartingPos.z && Direction == true)
        { transform.Translate(MoveRight * Time.deltaTime * _speed); }
        else if (transform.position.z >= StartingPos.z)
        { Direction = false; }
    }
}
