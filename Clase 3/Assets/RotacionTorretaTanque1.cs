using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTorretaTanque1 : MonoBehaviour {

	private AudioSource SonidoDisparoTanque;
	public GameObject prefab;
	public Transform puntoDeSalida;
	public float velocidadDeRotacion;
	private bool condicionDeDisparoInicial;
	private float tiempoDeRecarga = 0.0f;

	void Start () {
		SonidoDisparoTanque = GetComponent<AudioSource> ();
		condicionDeDisparoInicial = true;
	}

	void Update () 
	{
		if (!condicionDeDisparoInicial) 
		{
			tiempoDeRecarga += Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.E)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Q)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.Space) && tiempoDeRecarga >= 1.5f) 
		{
			SonidoDisparoTanque.Play ();
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
			tiempoDeRecarga = 0;
		}
		if (Input.GetKeyDown (KeyCode.Space) && condicionDeDisparoInicial)
		{
				Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
				SonidoDisparoTanque.Play ();
				condicionDeDisparoInicial = false;
		}
	}
}
