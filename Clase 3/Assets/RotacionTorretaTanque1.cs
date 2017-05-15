using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTorretaTanque1 : MonoBehaviour {

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

		if (Input.GetKey (KeyCode.E)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Q)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.Space) && condicionDeDisparoInicial == true)
		{
				Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
				condicionDeDisparoInicial = false;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && tiempoDeRecarga >= 1.5f) {
				Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
				tiempoDeRecarga = 0;
		}
	}
}
