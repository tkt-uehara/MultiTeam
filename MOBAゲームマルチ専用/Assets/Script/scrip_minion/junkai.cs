using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class junkai : MonoBehaviour
{
    
private NavMeshAgent agent;
 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextGoal();
       
    }
 
    void nextGoal(){
  var randomPos = new Vector3(Random.Range(0,5),0,Random.Range(0,5));
    agent.destination = randomPos;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(agent.remainingDistance);
        if(agent.remainingDistance < 0.5f){
        nextGoal();
        }
        
    }
}

