using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTorretaTanque : MonoBehaviour {

	public float velocidadDeRotacion;
	public KeyCode giroDerecha;
	public KeyCode giroIzquierda;

	void Start () {

	}

	void Update () 
	{
		if (Input.GetKey (giroDerecha)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKey (giroIzquierda)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
	}
}
