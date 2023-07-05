using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Ordinazione : AIState
{
    public Ordinazione(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _sportello, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, Transform _rifornimento, TextMeshProUGUI _ordinazioneCliente, GameObject _cliente)
       : base(_agent, _player, _ordine, _sportello, _frigorifero, _dispensa, _pianoCottura, _forno, _rifornimento, _ordinazioneCliente, _cliente)
    {
        Name = State.Ordinazione;
    }

    bool ordinare, conferma, next;
    int scelta;
    float timer;
    public override void Enter()
    {
        conferma = false;
        next = false;
        timer = 0;
        scelta = Random.Range(0, 3);
        agent.SetDestination(Sportello.position);
        if (Vector3.Distance(Sportello.position, Player.transform.position) < 4f)
            ordinare = true;

        base.Enter();
    }

    public override void Updata()
    {
        if (!Pronto())
        {
            if (ordinare)
            {
                timer += Time.deltaTime;
                SceltaOrdine(scelta);
                OrdinazioneCliente.text = "Vorei " + Ordine.name;
                conferma = true;
            }
            if (timer >= 2f && conferma)
            {
                OrdinazioneCliente.text = " ";
                ordinare = false;
                nextState = new Preparazione(agent, Player, Ordine, Sportello, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente, Cliente);
                Stage = Event.Exit;
            }
        }

        if (Pronto())
        {
            if (Vector3.Distance(Sportello.position, Player.transform.position) < 2)
            {
                timer += Time.deltaTime;
                OrdinazioneCliente.text = "Grazie, Arrivederci.";
                if (timer >= 2.5)
                {
                    next = true;
                }
            }
        }

        if (next)
        {
            Ordine.name = "Ordine";
            OrdinazioneCliente.text = " ";
            agent.SetDestination(new Vector3(0, 3f, 2f));
            nextState = new Idle(agent, Player, Ordine, Sportello, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente, Cliente);
            Stage = Event.Exit;
            return;
        }
        base.Updata();
    }


    void SceltaOrdine(int n)
    {
        switch (n)
        {
            case 0:
                Ordine.name = "Caviale Dei Poveri";
                break;
            case 1:
                Ordine.name = "Morzeddhu";
                break;
            case 2:
                Ordine.name = "Pittà 'nchiusa";
                break;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
