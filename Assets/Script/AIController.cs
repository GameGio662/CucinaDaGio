using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] Transform Sportello;
    [SerializeField] Transform Frigorifero;
    [SerializeField] Transform Dispensa;
    [SerializeField] Transform PianoCottura;
    [SerializeField] Transform Forno;
    [SerializeField] Transform Rifornimento;
    [SerializeField] GameObject Ordine;
    [SerializeField] GameObject Cliente;
    [SerializeField] TextMeshProUGUI OrdinazioneCliente;

    NavMeshAgent agent;
    AIState currentState;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new Idle(agent, this.gameObject, Ordine, Sportello, Frigorifero, Dispensa, PianoCottura, Forno, Rifornimento, OrdinazioneCliente, Cliente);
    }


    void Update()
    {
        currentState = currentState.Process();
        //Debug.Log(currentState.Name);
    }
}
