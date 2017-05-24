using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
	public Slider vida;
	private Scene escena;
	private float tiempoRegeneracionDeVidaSobreBotiquin = 0f;

	void Start ()
	{
		vida.value = 10;
		escena = SceneManager.GetActiveScene ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (vida.value > 0) {
			if (col.transform.tag == "Bala") {
				vida.value--;
			}
		} else {
			SceneManager.LoadScene(escena.name);
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
	}
}
