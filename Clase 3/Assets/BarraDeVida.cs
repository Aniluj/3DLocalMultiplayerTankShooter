using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
	public Slider vida;
	private Scene escena;

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
}
