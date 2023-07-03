using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Ordinare,

}

public enum Event
{
    Enter,
    Update,
    Exit
}
public class AIState
{
    public State Name;
    protected Event Stage;
    protected AIState nextState;
    protected NavMeshAgent agent;
    protected GameObject Player;
    protected Transform Cliente, Frigorifero, Dispensa, PianoCottura;

    float secondi;
    float minuti;

    public AIState(NavMeshAgent _agent, GameObject _player, Transform _cliente, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura)
    {
        Stage = Event.Enter;
        agent = _agent;
        Player = _player;
        Cliente = _cliente;
        Frigorifero = _frigorifero;
        Dispensa = _dispensa;
        PianoCottura = _pianoCottura;
    }

    public virtual void Enter() { Stage = Event.Update; }
    public virtual void Updata() { }
    public virtual void Exit() { Stage = Event.Exit; }

    public AIState Process()
    {
        if (Stage == Event.Enter) Enter();

        else if (Stage == Event.Update) Updata();

        else if (Stage == Event.Exit) { Exit(); return nextState; }

        return this;
    }

    #region Compiti

    public bool Apertura()
    {
        if (minuti < 20)
            secondi += Time.deltaTime;

        if (secondi >= 60)
        {
            secondi = 0;
            minuti = 1;
            if (minuti >= 20)
            {
                secondi = 0;
                minuti += Time.deltaTime;
                if (minuti == 24)
                {
                    minuti = 0;
                    return true;
                }
                return false;
            }
        }

        return true;
    }



    #endregion

}
