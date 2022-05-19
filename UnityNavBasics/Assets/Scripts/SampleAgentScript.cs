using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAgentScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Material normalColor;
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
     
                }
  
                }
            }            
        }

 
        
    }

}
