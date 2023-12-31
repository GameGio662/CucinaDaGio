using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Ordinazione,
    Preparazione,
    Rifornimento,
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
    protected GameObject Ordine;
    protected GameObject Cliente;
    protected Transform Sportello, Frigorifero, Dispensa, PianoCottura, Forno, rifornimentoCav, rifornimentoMorzeddhu, rifornimentoPitta;
    protected TextMeshProUGUI OrdinazioneCliente;

    float secondi;
    float minuti;

    public AIState(NavMeshAgent _agent, GameObject _player, GameObject _ordine, Transform _sportello,
        Transform _frigorifero, Transform _dispensa, Transform _pianoCottura, Transform _forno,
        Transform _rifornimento, TextMeshProUGUI _ordinazioneCliente,
        GameObject _cliente, Transform _rifornimentoMorzeddhu, Transform _rifornimentoPitta)
    {
        Stage = Event.Enter;
        agent = _agent;
        Player = _player;
        Ordine = _ordine;
        Sportello = _sportello;
        Frigorifero = _frigorifero;
        Dispensa = _dispensa;
        PianoCottura = _pianoCottura;
        Forno = _forno;
        rifornimentoCav = _rifornimento;
        rifornimentoMorzeddhu = _rifornimentoMorzeddhu;
        rifornimentoPitta = _rifornimentoPitta;
        OrdinazioneCliente = _ordinazioneCliente;
        Cliente = _cliente;
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
        if (Giorno.current.minuti >= 20 && Giorno.current.minuti <= 24 || Giorno.current.minuti >= 0 && Giorno.current.minuti < 8)
        {
            return false;
        }
        else
            return true;
    }

    public bool Pronto()
    {
        if (Ordine.name == "Pronto")
        {
            return true;
        }
        else if (Ordine.name == "Ordine")
        {
            return false;
        }

        return false;
    }

    public bool IngrCavPov()
    {
        if (Inventario.current.salsaPesce == 0 || Inventario.current.peperoncino == 0 || Inventario.current.sale == 0)
        {
            return false;
        }
        return true;
    }

    public bool IngrMors()
    {
        if (Inventario.current.nduja == 0 || Inventario.current.vitello == 0 || Inventario.current.pitta == 0)
        {
            return false;
        }
        return true;
    }

    public bool IngrPitNchiusa()
    {
        if (Inventario.current.fruttaSecca == 0 || Inventario.current.miele == 0 || Inventario.current.cannella == 0)
        {
            return false;
        }
        return true;
    }


    #endregion

}
