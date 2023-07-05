using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _sportello, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, Transform _rifornimento, TextMeshProUGUI _ordinazioneCliente, GameObject _cliente) 
        : base(_agent, _player, _ordine, _sportello, _frigorifero, _dispensa, _pianoCottura, _forno, _rifornimento, _ordinazioneCliente, _cliente)
    {
        Name = State.Idle;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Updata()
    {
        if (Vector3.Distance(new Vector3(0, 3, 2), Player.transform.position) <= 2f)
            if (Apertura())
            {
                nextState = new Ordinazione(agent, Player, Ordine, Sportello, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente, Cliente);
                Stage = Event.Exit;
                Cliente.SetActive(true);
                return;
            }
            else if (!Apertura())
            {
                agent.SetDestination(new Vector3(0, 3f, 2));
                Cliente.SetActive(false);
            }

        base.Updata();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
