using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Ordinazione : AIState
{
    public Ordinazione(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _cliente, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, TextMeshProUGUI _ordinazioneCliente)
         : base(_agent, _player, _ordine, _cliente, _frigorifero, _dispensa, _pianoCottura, _forno, _ordinazioneCliente)
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

        agent.SetDestination(Cliente.position);
        if (Vector3.Distance(Cliente.position, Player.transform.position) < 3)
            ordinare = true;

        base.Enter();
    }

    public override void Updata()
    {
        Debug.Log(ordinare);
        if (!Pronto())
        {
            if (ordinare)
            {
                scelta = 0; //Random.Range(0, 3);
                SceltaOrdine(scelta);
                OrdinazioneCliente.text = "Vorei " + Ordine.name + "           Premi Space Per Continuare";
                conferma = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && conferma)
            {
                OrdinazioneCliente.text = " ";
                ordinare = false;
                nextState = new Preparazione(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, OrdinazioneCliente);
                Stage = Event.Exit;
            }
        }

        if (Pronto())
        {
            if (Vector3.Distance(Cliente.position, Player.transform.position) < 2)
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
            nextState = new Idle(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, OrdinazioneCliente);
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
