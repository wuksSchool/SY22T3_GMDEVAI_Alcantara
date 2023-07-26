using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject obstacle;
    GameObject instantiatedObj;
    GameObject[] agents;
    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                instantiatedObj = Instantiate(obstacle, hit.point, obstacle.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIBehavior>().FleeObstacle(hit.point);
                }
                StartCoroutine(WaitForDestruction());

            }
        }
        else if (Input.GetMouseButtonDown(1)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                instantiatedObj = Instantiate(obstacle, hit.point, obstacle.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIBehavior>().FlockObstacle(hit.point);
                }
                StartCoroutine(WaitForDestruction());
            }
        }
        
    }

    IEnumerator WaitForDestruction() 
    {
        yield return new WaitForSeconds(2f);
        Destroy(instantiatedObj);
    }
}
