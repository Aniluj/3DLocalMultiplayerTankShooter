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

	void Start () {
		condicionDeDisparoInicial = true;
	}

	void Update () {
        if(!isLocalPlayer)
        {
            return;
        }

		if (!condicionDeDisparoInicial) 
		{
			tiempoDeRecarga += Time.deltaTime;
		}
		if (Input.GetKeyDown (disparo) && tiempoDeRecarga >= 1.5f) 
		{
            CmdFire();
		}
		if (Input.GetKeyDown (disparo) && condicionDeDisparoInicial)
		{
            CmdFire();
		}
	}

    [Command]
    private void CmdFire()
    {
        GameObject bullet = Instantiate(prefab, puntoDeSalida.position, puntoDeSalida.rotation);
        SonidoDisparoTanque.Play();
        tiempoDeRecarga = 0;
        NetworkServer.Spawn(bullet);
    }
}
