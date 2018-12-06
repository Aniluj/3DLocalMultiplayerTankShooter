using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Disparo : NetworkBehaviour {

    public AudioSource SonidoDisparoTanque;
    private bool condicionDeDisparoInicial;

    private float tiempoDeRecarga = 0f;

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
            
            if (!condicionDeDisparoInicial)
            {
                tiempoDeRecarga += Time.deltaTime;
            }

            if (Input.GetKeyDown(disparo) && tiempoDeRecarga >= 0.75f)
            {
                CmdFire();
                tiempoDeRecarga = 0.0f;
            }
            if(Input.GetKeyDown(disparo) && condicionDeDisparoInicial)
            {
                condicionDeDisparoInicial = false;
                tiempoDeRecarga = 0.0f;
                CmdFire();
            }
        }
    }

    [Command]
    private void CmdFire()
    {
        GameObject bullet = Instantiate(prefab, puntoDeSalida.position, puntoDeSalida.rotation);
        SonidoDisparoTanque.Play();
        NetworkServer.Spawn(bullet);
    }
}
