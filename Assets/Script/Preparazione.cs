using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Preparazione : AIState
{
    public Preparazione(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _cliente, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, TextMeshProUGUI _ordinazioneCliente)
         : base(_agent, _player, _ordine, _cliente, _frigorifero, _dispensa, _pianoCottura, _forno, _ordinazioneCliente)
    {
        Name = State.Preparazione;
    }

    float timer;
    int next;

    public override void Enter()
    {
        base.Enter();
    }


    public override void Updata()
    {
        if (Ordine.name == "Caviale Dei Poveri")
            CavialeDeiPoveri();
        if (Ordine.name == "Morzeddhu")
            Morzeddhu();
        if (Ordine.name == "Pitt‡ 'nchiusa")
            Pitt‡Nchiusa();
        base.Updata();
    }


    void CavialeDeiPoveri()
    {
        if (next == 0)
        {
            agent.SetDestination(Frigorifero.position);


            if (Vector3.Distance(Frigorifero.position, Player.transform.position) < 2)
            {

                timer += Time.deltaTime;
                if (timer >= 1)
                {
                    OrdinazioneCliente.text = "Preso Salsa di Bianchetto";
                    timer = 0;
                    next = 2;
                }
            }
        }
        else if (next == 2)
        {
            agent.SetDestination(Dispensa.position);


            if (Vector3.Distance(Dispensa.position, Player.transform.position) < 2)
            {
                timer += Time.deltaTime;
                if (timer >= 1 && timer <= 2.5f)
                {
                    OrdinazioneCliente.text = "Preso Peperoncino";
                }
                if (timer >= 2.5f && timer <= 3.5f)
                {
                    OrdinazioneCliente.text = "Preso Sale";
                    timer = 0;
                    next = 3;
                }

            }
        }
        if (next == 3)
        {
            agent.SetDestination(PianoCottura.position);

            timer += Time.deltaTime;
            if (Vector3.Distance(PianoCottura.position, Player.transform.position) < 2)
            {
                if (timer >= 1 && timer <= 2)
                {
                    OrdinazioneCliente.text = "Hai Ottenuto " + Ordine.name;
                }

                if (timer >= 2.5f)
                {
                    OrdinazioneCliente.text = " ";
                    Ordine.name = "Pronto";
                    timer = 0;
                    next = 0;
                    nextState = new Ordinazione(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, OrdinazioneCliente);
                    Stage = Event.Exit;
                    return;

                }
            }
        }
    }

    void Morzeddhu()
    {

    }

    void Pitt‡Nchiusa()
    {

    }

    public override void Exit()
    {
        base.Exit();
    }


}
