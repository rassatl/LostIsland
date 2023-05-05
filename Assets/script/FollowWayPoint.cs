using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoint : MonoBehaviour
{
    //You may consider adding a rigid body to the zombie for accurate physics simulation
    public GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 6.0f;

    void Update ()
    {
    wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
    //Here, the zombie's will follow the waypoint.
    transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
}
