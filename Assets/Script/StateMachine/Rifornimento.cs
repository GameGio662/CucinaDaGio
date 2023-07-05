using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Rifornimento : AIState
{
    public Rifornimento(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _sportello, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, Transform _rifornimento, TextMeshProUGUI _ordinazioneCliente, GameObject _cliente)
      : base(_agent, _player, _ordine, _sportello, _frigorifero, _dispensa, _pianoCottura, _forno, _rifornimento, _ordinazioneCliente, _cliente)
    {
        Name = State.Rifornimento;
    }


    public override void Enter()
    {
        agent.SetDestination(rifornimento.position);
        base.Enter();
    }

    public override void Updata()
    {
        if (Vector3.Distance(rifornimento.position, Player.transform.position) <= 1.5f)
        {
            OrdinazioneCliente.text = " ";
            if (!IngrCavPov())
            {
                Inventario.current.salsaPesce = 5;
                Inventario.current.peperoncino = 5;
                Inventario.current.sale = 5;
                RitornaAPreparare();
            }

            if (!IngrMors())
            {
                Inventario.current.nduja = 5;
                Inventario.current.vitello= 5;
                Inventario.current.pitta = 5;
                RitornaAPreparare();
            }

            if(!IngrPitNchiusa())
            {
                Inventario.current.fruttaSecca = 5;
                Inventario.current.miele = 5;
                Inventario.current.cannella = 5;
                RitornaAPreparare();
            }
        }
        base.Updata();
    }



    void RitornaAPreparare()
    {
        nextState = new Preparazione(agent, Player, Ordine, Sportello, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente, Cliente);
        Stage = Event.Exit;
        return;
    }



    public override void Exit()
    {
        base.Exit();
    }
}
