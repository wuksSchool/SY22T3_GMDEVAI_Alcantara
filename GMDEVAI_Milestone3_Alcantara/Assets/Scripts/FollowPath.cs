using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Checks if graph has waypoints inside or if we are within the bounds of waypoint count
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength()) 
        {
            return;
        }

        //Node we are closest to at the moment
        currentNode = graph.getPathPoint(currentWaypointIndex);

        //If close enough to the current waypoint, move to the next one
        //(closest waypoint, current position)
        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position, transform.position) < accuracy) 
        {
            currentWaypointIndex++;
        }

        //if we are at the end of the path
        if (currentWaypointIndex < graph.getPathLength()) 
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void GoToTwinMountains() 
    {
        graph.AStar(currentNode, wps[2]);
        currentWaypointIndex = 0;
    }

    public void GoToBarracks() 
    {
        graph.AStar(currentNode, wps[7]);
        currentWaypointIndex = 0;
    }
    public void GoToCommandCenter()
    {
        graph.AStar(currentNode, wps[0]);
        currentWaypointIndex = 0;
    }
    public void GoToOilRefineryPumps()
    {
        graph.AStar(currentNode, wps[9]);
        currentWaypointIndex = 0;
    }
    public void GoToTankers()
    {
        graph.AStar(currentNode, wps[10]);
        currentWaypointIndex = 0;
    }
    public void GoToRadar()
    {
        graph.AStar(currentNode, wps[4]);
        currentWaypointIndex = 0;
    }
    public void GoToCommandPost()
    {
        graph.AStar(currentNode, wps[5]);
        currentWaypointIndex = 0;
    }
    public void GoToMiddle()
    {
        graph.AStar(currentNode, wps[8]);
        currentWaypointIndex = 0;
    }
}
