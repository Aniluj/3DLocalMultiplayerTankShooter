using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Disparo : NetworkBehaviour {

    public AudioSource SonidoDisparoTanque;
    private bool condicionDeDisparoInicial;
   // [SyncVar(hook = "RpcUpdateTimer")]
   // private float tiempoDeRecarga = 0f;

    public GameObject prefab;
    public KeyCode disparo;
    public Transform puntoDeSalida;

    void Start() {
        if(!isLocalPlayer)
        {
            return;
        }
        else
        {
            condicionDeDisparoInicial = true;
        }
    }

    void Update() {
        if(!isLocalPlayer)
        {
            return;
        }
        else
        {
            /*if(Input.GetKeyDown(disparo) && tiempoDeRecarga >= 0.75f)
            {
                CmdFire();
            }*/
            if(Input.GetKeyDown(disparo) && condicionDeDisparoInicial)
            {
                CmdFire();
            }
        }
    }

    /*[ClientRpc]
    private void RpcUpdateTimer(float tiempoRecibido)
    {
        if(!isServer)
        {
            return;
        }
        
        if(condicionDeDisparoInicial)
        {
            condicionDeDisparoInicial = false;
        }
        else
        {
            tiempoDeRecarga = Time.deltaTime;
        }
    }*/

    [Command]
    private void CmdFire()
    {
        GameObject bullet = Instantiate(prefab, puntoDeSalida.position, puntoDeSalida.rotation);
        SonidoDisparoTanque.Play();
        NetworkServer.Spawn(bullet);
    }
}
