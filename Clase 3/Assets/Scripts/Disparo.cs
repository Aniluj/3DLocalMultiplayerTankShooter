using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Disparo : MonoBehaviour {

	private AudioSource SonidoDisparoTanque;
	private bool condicionDeDisparoInicial;
	private float tiempoDeRecarga = 0f;
	public GameObject prefab;
	public KeyCode disparo;
	public Transform puntoDeSalida;

	void Start () {
		SonidoDisparoTanque = GetComponent<AudioSource> ();
		condicionDeDisparoInicial = true;
	}

	void Update () {
		if (!condicionDeDisparoInicial) 
		{
			tiempoDeRecarga += Time.deltaTime;
		}
		if (Input.GetKeyDown (disparo) && tiempoDeRecarga >= 1.5f) 
		{
			SonidoDisparoTanque.Play ();
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
			tiempoDeRecarga = 0;
		}
		if (Input.GetKeyDown (disparo) && condicionDeDisparoInicial)
		{
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
			SonidoDisparoTanque.Play ();
			condicionDeDisparoInicial = false;
		}
	}
}
