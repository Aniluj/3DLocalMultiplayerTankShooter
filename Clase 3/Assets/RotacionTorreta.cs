using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTorreta : MonoBehaviour {

	public GameObject prefab;
	public Transform puntoDeSalida;

	void Update () 
	{
		if (Input.GetKey (KeyCode.E)) 
		{
			transform.Rotate (Vector3.up * Time.deltaTime*10);
		}
		if (Input.GetKey (KeyCode.Q)) 
		{
			transform.Rotate (-Vector3.up * Time.deltaTime * 10);
		}
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Instantiate (prefab, puntoDeSalida.position, puntoDeSalida.rotation);
		}
	}
}
