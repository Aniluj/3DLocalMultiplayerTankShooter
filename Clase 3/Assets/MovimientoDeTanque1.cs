using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDeTanque1 : MonoBehaviour 
{
	public float velocidadDeMovimiento;
	public float velocidadDeRotacion;
	public float fuerzaHaciaAbajo;
	private Rigidbody rigidBodyTanque1;

	void Start () {
		rigidBodyTanque1 = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			rigidBodyTanque1.AddRelativeForce (Vector3.right * velocidadDeMovimiento, ForceMode.Force);
		}	
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			rigidBodyTanque1.AddRelativeForce (-Vector3.right * velocidadDeMovimiento, ForceMode.Force);
		}
	}
}
