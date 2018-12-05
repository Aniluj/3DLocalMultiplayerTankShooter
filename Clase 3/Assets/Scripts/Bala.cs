using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Bala : MonoBehaviour {

	public float fuerza;

	void Start () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddRelativeForce (Vector3.right * fuerza, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision col)
	{
        Vida vida = col.gameObject.GetComponent<Vida>();
        if(vida != null)
        {
            vida.HacerDanio(1);
            if(vida.vidaActual <= 0)
            {
                vida.RegenerarVida(10);
            }
        }
		Destroy (this.gameObject);
	}
}
