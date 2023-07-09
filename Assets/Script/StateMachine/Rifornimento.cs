using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Rifornimento : AIState
{
    public Rifornimento(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _sportello, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, Transform _rifornimento, TextMeshProUGUI _ordinazioneCliente, GameObject _cliente, Transform _rifornimentoMorzeddhu, Transform _rifornimentoPitta)
        : base(_agent, _player, _ordine, _sportello, _frigorifero, _dispensa, _pianoCottura, _forno, _rifornimento, _ordinazioneCliente, _cliente, _rifornimentoMorzeddhu, _rifornimentoPitta)
    {
        Name = State.Rifornimento;
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Updata()
    {
        OrdinazioneCliente.text = " ";
        if (!IngrCavPov() && Ordine.name == "Caviale Dei Poveri")
        {
            agent.SetDestination(rifornimentoCav.position);
            if (Vector3.Distance(rifornimentoCav.position, Player.transform.position) < 3)
            {
                Inventario.current.salsaPesce = 5;
                Inventario.current.peperoncino = 5;
                Inventario.current.sale = 5;
                RitornaAPreparare();

            }
        }

        if (!IngrMors() && Ordine.name == "Morzeddhu")
        {
            agent.SetDestination(rifornimentoMorzeddhu.position);
            if (Vector3.Distance(rifornimentoMorzeddhu.position, Player.transform.position) < 3)
            {
                Inventario.current.nduja = 5;
                Inventario.current.vitello = 5;
                Inventario.current.pitta = 5;
                RitornaAPreparare();

            }
        }

        if (!IngrPitNchiusa() && Ordine.name == "Pittà 'nchiusa")
        {
            agent.SetDestination(rifornimentoPitta.position);
            if (Vector3.Distance(rifornimentoPitta.position, Player.transform.position) < 3)
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
        nextState = new Preparazione(agent, Player, Ordine, Sportello, Frigorifero, Dispensa,
            PianoCottura, Forno, rifornimentoCav, OrdinazioneCliente, Cliente, rifornimentoMorzeddhu, rifornimentoPitta);
        Stage = Event.Exit;
        return;
    }



    public override void Exit()
    {
        base.Exit();
    }
}
