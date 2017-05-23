using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTorretaTanque2 : MonoBehaviour {

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
		if (Input.GetKey (KeyCode.Keypad9)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Keypad7)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.KeypadEnter) && tiempoDeRecarga >= 1.5f) 
		{
			SonidoDisparoTanque.Play ();
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
			tiempoDeRecarga = 0;
		}
		if (Input.GetKeyDown (KeyCode.KeypadEnter) && condicionDeDisparoInicial)
		{
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
			SonidoDisparoTanque.Play ();
			condicionDeDisparoInicial = false;
		}
	}
}
