using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTanque : MonoBehaviour 
{
	public int speed;

	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector3.right * Time.deltaTime*speed);
		}	
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate (Vector3.up * speed);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate (-Vector3.up * speed);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (-Vector3.right * Time.deltaTime*speed);
		}
	}
}
