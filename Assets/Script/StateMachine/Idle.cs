using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _sportello, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, Transform _rifornimento, TextMeshProUGUI _ordinazioneCliente, GameObject _cliente, Transform _rifornimentoMorzeddhu, Transform _rifornimentoPitta) : 
        base(_agent, _player, _ordine, _sportello, _frigorifero, _dispensa, _pianoCottura, _forno, _rifornimento, _ordinazioneCliente, _cliente, _rifornimentoMorzeddhu, _rifornimentoPitta)
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
                OrdinazioneCliente.text = " ";
                nextState = new Ordinazione(agent, Player, Ordine, Sportello, Frigorifero, Dispensa, 
                    PianoCottura, Forno, rifornimentoCav, OrdinazioneCliente, Cliente, rifornimentoMorzeddhu, rifornimentoPitta);
                Stage = Event.Exit;
                Cliente.SetActive(true);
                return;
            }
            else if (!Apertura())
            {
                OrdinazioneCliente.text = "ZzZzZzZz";
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
