using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject objectToMove;

    public Transform StartPoint;
    public Transform EndPoint;

    public float speed;
    private Vector3 moveTowards;

    // Start is called before the first frame update
    void Start()
    {
       moveTowards = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, moveTowards, speed * Time.deltaTime);

        if(objectToMove.transform.position == EndPoint.position)
        {
            moveTowards = StartPoint.position;
        }

        if (objectToMove.transform.position == StartPoint.position)
        {
            moveTowards = EndPoint.position;
        }
    }
}

