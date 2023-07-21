using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    GameObject[] agents;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000)) 
            {
                
            }
        }*/

        FollowPlayer();
    }

    private void FollowPlayer() 
    {
        foreach (GameObject ai in agents)
        {
            ai.GetComponent<AIControl>().agent.SetDestination(player.transform.position);
        }
    }
}
