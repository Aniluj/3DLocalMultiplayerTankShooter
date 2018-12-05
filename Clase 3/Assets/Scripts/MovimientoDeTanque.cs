using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class MovimientoDeTanque : NetworkBehaviour 
{
	public float velocidadDeMovimiento;
	public float velocidadDeRotacion;
	public KeyCode rotacionDerecha;
	public KeyCode rotacionIzquierda;
	public KeyCode movimientoAdelante;
	public KeyCode movimientoAtras;
	private Rigidbody rigidBodyTanque;

	void Start () {
        if(!isLocalPlayer)
        {
            GetComponentInChildren<Camera>().enabled = false;
        }
        else
        {
            rigidBodyTanque = GetComponent<Rigidbody>();
        }
    }

	void Update () 
	{
        if(!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKey (movimientoAdelante)) 
		{
			rigidBodyTanque.AddRelativeForce (Vector3.right * velocidadDeMovimiento, ForceMode.Force);
		}	
		if (Input.GetKey (rotacionIzquierda)) 
		{
			transform.Rotate (-Vector3.up * velocidadDeRotacion);
		}
		if (Input.GetKey (rotacionDerecha)) 
		{
			transform.Rotate (Vector3.up * velocidadDeRotacion);
		}
		if (Input.GetKey (movimientoAtras)) 
		{
			rigidBodyTanque.AddRelativeForce (-Vector3.right * velocidadDeMovimiento, ForceMode.Force);
		}
	}
}
