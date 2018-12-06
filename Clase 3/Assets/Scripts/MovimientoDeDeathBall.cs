using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class MovimientoDeDeathBall : NetworkBehaviour {

    private bool movimientoHaciaAdelante;
    private Transform transformDeDeathBall;


    private void Start()
    {
        if (!isServer)
        {
            return;
        }
        movimientoHaciaAdelante = true;
        transformDeDeathBall = gameObject.GetComponent<Transform>();
    }

    void Update () {
		
        //isLocalPlayer

        if(!isServer)
        {
            return;
        }

        if (transform.position.z <= 429 && movimientoHaciaAdelante)
        {
            Debug.Log("adelante");
            transform.Translate(Vector3.forward * Time.deltaTime * 50);
            if (transform.position.z >= 429)
            {
                movimientoHaciaAdelante = false;
            }
        }
        if (movimientoHaciaAdelante == false)
        {
            Debug.Log("dsafas");
            transform.Translate(-Vector3.forward * Time.deltaTime * 50);
            if (transform.position.z <= 75)
            {
                movimientoHaciaAdelante = true;
            }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        Vida vida = col.gameObject.GetComponent<Vida>();

        if (vida != null)
        {
            vida.HacerDanio(10);
            if (vida.vidaActual <= 0)
            {
                vida.RegenerarVida(10);
            }
        }
    }
}
