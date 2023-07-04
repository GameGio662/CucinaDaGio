using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] Transform Cliente;
    [SerializeField] Transform Frigorifero;
    [SerializeField] Transform Dispensa;
    [SerializeField] Transform PianoCottura;
    [SerializeField] Transform Forno;
    [SerializeField] GameObject Ordine;
    [SerializeField] TextMeshProUGUI OrdinazioneCliente;

    NavMeshAgent agent;
    AIState currentState;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new Idle(agent, this.gameObject, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, OrdinazioneCliente);
    }


    void Update()
    {
        currentState = currentState.Process();
        //Debug.Log(currentState.Name);
    }
}
