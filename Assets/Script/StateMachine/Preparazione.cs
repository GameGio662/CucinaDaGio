using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Preparazione : AIState
{
    public Preparazione(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _cliente, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno, Transform _rifornimento, TextMeshProUGUI _ordinazioneCliente)
        : base(_agent, _player, _ordine, _cliente, _frigorifero, _dispensa, _pianoCottura, _forno, _rifornimento, _ordinazioneCliente)
    {
        Name = State.Preparazione;
    }

    float timer;
    int next;

    public override void Enter()
    {
        timer = 0;
        next = 0;
        base.Enter();
    }


    public override void Updata()
    {
        if (Ordine.name == "Caviale Dei Poveri")
            if (IngrCavPov())
                CavialeDeiPoveri();
            else
                Riforn();
        if (Ordine.name == "Morzeddhu")
            if (IngrMors())
                Morzeddhu();
            else
                Riforn();
        if (Ordine.name == "Pitt‡ 'nchiusa")
            if (IngrPitNchiusa())
                Pitt‡Nchiusa();
            else
                Riforn();

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
                if (timer >= 1 && timer <= 2f)
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
                    Inventario.current.salsaPesce--;
                    Inventario.current.peperoncino--;
                    Inventario.current.sale--;
                    nextState = new Ordinazione(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente);
                    Stage = Event.Exit;
                    return;

                }
            }
        }
    }

    void Morzeddhu()
    {
        if (next == 0)
        {
            agent.SetDestination(Frigorifero.position);


            if (Vector3.Distance(Frigorifero.position, Player.transform.position) < 2)
            {

                timer += Time.deltaTime;
                if (timer >= 1 && timer <= 2f)
                {
                    OrdinazioneCliente.text = "Preso 'nduja";

                }
                if (timer >= 2.5f && timer <= 3.5f)
                {
                    OrdinazioneCliente.text = "Preso Carne Di Vitello";

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
                if (timer >= 1)
                {
                    OrdinazioneCliente.text = "Preso Pezzo di Pitta";
                    timer = 0;
                    next = 3;
                }
            }
        }
        if (next == 3)
        {
            agent.SetDestination(Forno.position);

            timer += Time.deltaTime;
            if (Vector3.Distance(Forno.position, Player.transform.position) < 2)
            {
                if (timer >= 1 && timer <= 2)
                {
                    OrdinazioneCliente.text = "Hai Ottenuto " + Ordine.name;
                }

                if (timer >= 2.5f)
                {
                    OrdinazioneCliente.text = " ";
                    Ordine.name = "Pronto";
                    Inventario.current.nduja--;
                    Inventario.current.vitello--;
                    Inventario.current.pitta--;
                    nextState = new Ordinazione(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente);
                    Stage = Event.Exit;
                    return;

                }
            }
        }
    }

    void Pitt‡Nchiusa()
    {
        if (next == 0)
        {
            agent.SetDestination(Frigorifero.position);


            if (Vector3.Distance(Frigorifero.position, Player.transform.position) < 2)
            {

                timer += Time.deltaTime;
                if (timer >= 1)
                {
                    OrdinazioneCliente.text = "Preso Frutta Secca";
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
                if (timer >= 1 && timer <= 2f) 
                {
                    OrdinazioneCliente.text = "Preso Miele";
                    
                }
                if (timer >= 2.5f && timer <= 3.5f)
                {
                    OrdinazioneCliente.text = "Preso Cannella";
                    timer = 0;
                    next = 3;
                }
            }
        }
        if (next == 3)
        {
            agent.SetDestination(Forno.position);

            timer += Time.deltaTime;
            if (Vector3.Distance(Forno.position, Player.transform.position) < 2)
            {
                if (timer >= 1 && timer <= 2)
                {
                    OrdinazioneCliente.text = "Hai Ottenuto " + Ordine.name;
                }

                if (timer >= 2.5f)
                {
                    OrdinazioneCliente.text = " ";
                    Ordine.name = "Pronto";
                    Inventario.current.fruttaSecca--;
                    Inventario.current.miele--;
                    Inventario.current.cannella--;
                    nextState = new Ordinazione(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente);
                    Stage = Event.Exit;
                    return;

                }
            }
        }
    }

    void Riforn()
    {
        OrdinazioneCliente.text = "mi mancano alcuni ingredienti per " + Ordine.name;
        nextState = new Rifornimento(agent, Player, Ordine, Cliente, Frigorifero, Dispensa, PianoCottura, Forno, rifornimento, OrdinazioneCliente);
        Stage = Event.Exit;
        return;
    }

    public override void Exit()
    {
        base.Exit();
    }


}
