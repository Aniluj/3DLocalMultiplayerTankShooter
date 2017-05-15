using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTorretaTanque2 : MonoBehaviour {

	public GameObject prefab;
	public Transform puntoDeSalida;
	public float velocidadDeRotacion;
	private bool condicionDeDisparoInicial;
	private float tiempoDeRecarga = 0.0f;

	void Start () {
		condicionDeDisparoInicial = true;
	}

	void Update () 
	{
		tiempoDeRecarga += Time.deltaTime;

		if (Input.GetKey (KeyCode.Keypad9)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Keypad7)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.KeypadEnter) && condicionDeDisparoInicial == true)
		{
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
			condicionDeDisparoInicial = false;
		}
		else if (Input.GetKeyDown (KeyCode.KeypadEnter) && tiempoDeRecarga >= 1.5f) {
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
			tiempoDeRecarga = 0;
		}
	}
}
