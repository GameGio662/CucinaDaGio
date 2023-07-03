using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(NavMeshAgent _agent, GameObject _player, Transform _cliente, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura) 
        : base(_agent, _player, _cliente, _frigorifero, _dispensa, _pianoCottura)
    {
        Name = State.Idle;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Updata()
    {
        if (Apertura)
        {
            nextState = new Ordinazione(agent, Player, Cliente, Frigorifero, Dispensa, PianoCottura);
            Stage = Event.Exit;
            return;
        }

        base.Updata();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
