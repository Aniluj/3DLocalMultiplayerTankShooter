using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
	public Slider vida;

	void Start ()
	{
		vida.value = 10;
	}

	void OnCollisionEnter(Collision col)
	{
		if (vida.value > 0) {
			if (col.transform.tag == "Bala") {
				vida.value--;
			}
		}
	}
}
