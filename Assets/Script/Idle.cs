using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _cliente, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, TextMeshProUGUI _ordinazioneCliente)
        : base(_agent, _player, _ordine, _cliente, _frigorifero, _dispensa, _pianoCottura, _forno, _ordinazioneCliente)
    {
        Name = State.Idle;
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Updata()
    {
        if (Vector3.Distance(new Vector3(0, 3, 2), Player.transform.position) <= 1.5)
            if (Apertura())
            {
                nextState = new Ordinazione(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, OrdinazioneCliente);
                Stage = Event.Exit;
                return;
            }
            else if (!Apertura())
            {
                agent.SetDestination(new Vector3(0, 3f, 0));
                Debug.Log("siamo chiusi");
            }

        base.Updata();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
