using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public GameObject[] wayPoints;
    int current = 0; //which waypoint in array currently heading to 
    float rotSpeed; //rotate speed
    public float speed;
    float WPradius = 1.0f; //radius of waypoint to make sure gameObject doesn't miss waypoint

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(wayPoints[current].transform.position, transform.position) < WPradius ){
            current++;
            if(current>=wayPoints.Length){
                current=0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[current].transform.position, Time.deltaTime*speed);
    }
}
