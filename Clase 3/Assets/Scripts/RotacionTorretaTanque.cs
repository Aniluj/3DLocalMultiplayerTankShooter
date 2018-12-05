using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class RotacionTorretaTanque : NetworkBehaviour {

    public float velocidadDeRotacion;
    public KeyCode giroDerecha;
    public KeyCode giroIzquierda;

    public GameObject turret;
    private Transform turretTransform;

	void Start () {

        if(isLocalPlayer)
        {
            turretTransform = turret.GetComponent<Transform>();
            Debug.Log("dsassff");
        }

    }

	void Update () 
	{
        if(!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKey (giroDerecha)) 
		{
            turretTransform.Rotate (Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
		if (Input.GetKey (giroIzquierda)) 
		{
            turretTransform.Rotate (-Vector3.up * velocidadDeRotacion * Time.deltaTime);
		}
	}
}
