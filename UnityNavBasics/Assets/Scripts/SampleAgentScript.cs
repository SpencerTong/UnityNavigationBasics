using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAgentScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Material normalColor;
    public bool goalReached = false; 

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();    
    }

       // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Renderer>().material.color ==Color.red){
            if (Input.GetMouseButtonDown(0)){
               RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)){
                GameObject objHit = hit.collider.gameObject; 
                if (objHit.CompareTag("Floor")){
                    agent.destination = hit.point;
                    gameObject.GetComponent<Renderer>().material = normalColor;
                    agent.isStopped = false;

                }
  
                }
            }            
        }

    
        if (!agent.pathPending)
        {
        if (agent.remainingDistance != 0 && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                goalReached = true; 
            }
        }
    }
 }
 
        
 

 
        
    

    void OnTriggerStay(Collider collider){
        if (gameObject.GetComponent<Renderer>().material.color==Color.red){
            goalReached = false;
        } else if (collider.gameObject.CompareTag("Agents")){
            Vector3 destination = collider.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().destination;
            if (destination==agent.destination){

                if(collider.gameObject.GetComponent<SampleAgentScript>().goalReached){
                    goalReached = true;
                    agent.isStopped = true;
                }
            }
        }
    }

}