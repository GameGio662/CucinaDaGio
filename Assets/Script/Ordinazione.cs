using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Ordinazione : AIState
{
    public Ordinazione(NavMeshAgent _agent, GameObject _player, Transform _cliente, Transform _frigorifero, Transform _dispensa, Transform _pianoCottura)
        : base(_agent, _player, _cliente, _frigorifero, _dispensa, _pianoCottura)
    {
        Name = State.Ordinare;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Updata()
    {
        base.Updata();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
