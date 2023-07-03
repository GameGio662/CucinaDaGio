using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] Transform Cliente;
    [SerializeField] Transform Frigorifero;
    [SerializeField] Transform Dispenza;
    [SerializeField] Transform PianoCottura;

    NavMeshAgent agent;
    AIState currentState;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new Idle(agent, this.gameObject, Cliente, Frigorifero, Dispenza, PianoCottura);
    }


    void Update()
    {
        currentState = currentState.Process();
        Debug.Log(currentState.Name);
    }
}
