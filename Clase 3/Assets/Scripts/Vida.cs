using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Vida : NetworkBehaviour
{
    [SyncVar(hook = "OnChangeHealth")]
    public int vidaActual = vidaMaxima;

    public const int vidaMaxima = 10;

    public Slider vida;
	private Scene escena;

	//private float tiempoRegeneracionDeVidaSobreBotiquin = 0f;

	/*void Start ()
	{
		vida.value = 10;
		escena = SceneManager.GetActiveScene ();
	}*/

    public void HacerDanio(int danioInfligido) {
        if(!isServer)
        {
            return;
        }

        vidaActual -= danioInfligido;

        if(vidaActual <= 0)
        {
            vidaActual = 0;
            RpcRespawn();
        }
    }

    public void RegenerarVida(int vidaRegenerada)
    {
        if(!isServer)
        {
            return;
        }

        vidaActual += vidaRegenerada;

        if(vidaActual >= vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }

    void OnChangeHealth(int vidaRecibida) 
    {
        vida.value = vidaRecibida;
        //healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn() {
        if(isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }

    /*void OnCollisionEnter(Collision col)
	{
		if (vida.value > 0) {
			if (col.transform.tag == "Bala") {
				vida.value--;
			}
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Botiquin") {
			tiempoRegeneracionDeVidaSobreBotiquin += Time.deltaTime;
			if (tiempoRegeneracionDeVidaSobreBotiquin >= 2f) {
				tiempoRegeneracionDeVidaSobreBotiquin = 0f;
				vida.value += 1;
			}
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Botiquin") {
			tiempoRegeneracionDeVidaSobreBotiquin = 0f;
		}
	}*/
}
