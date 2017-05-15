using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDeTanque2 : MonoBehaviour 
{
	public float velocidadDeMovimiento;
	public float velocidadDeRotacion;
	private Rigidbody rigidBodyTanque2;

	void Start () {
		rigidBodyTanque2 = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.Keypad8)) 
		{
			rigidBodyTanque2.AddRelativeForce (Vector3.right * velocidadDeMovimiento, ForceMode.Force);
		}
		if (Input.GetKey (KeyCode.Keypad6)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion);
		}
		if (Input.GetKey (KeyCode.Keypad4)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion);
		}
		if (Input.GetKey (KeyCode.Keypad5)) 
		{
			rigidBodyTanque2.AddRelativeForce (-Vector3.right * velocidadDeMovimiento, ForceMode.Force);
		}
	}
}
