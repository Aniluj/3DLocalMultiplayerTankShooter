using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

	public Slider vida;
	public GameObject[] puntosDeSpawn;
	public KeyCode teclaParaRespawnear;

	void Start () {
		
	}

	void Update () {
		if (vida.value == 10) {
			if (Input.GetKeyDown (teclaParaRespawnear)) {
				
			}
		}
	}
}
