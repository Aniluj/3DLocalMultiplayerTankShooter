using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	public Slider barraVida;
	public Slider vidaEnemigo;
	public Text vidas;
	public Text victoriaODerrota;
	public GameObject[] puntosDeSpawn;
	public KeyCode teclaParaReiniciar;
	public Camera camaraDeSeguimiento;
	private int vidasRestantes;
	private Scene escena;
	private int vecesQueMurio = 0;
	private int muertesEnemigo = 0;

	void Start () {
		vidasRestantes = 3;
		escena = SceneManager.GetActiveScene ();
	}

	void Update () {
		vidas.text = vidasRestantes.ToString();
		if (barraVida.value <= 0 && vecesQueMurio < 3) {
			vidasRestantes--;
			vecesQueMurio++;
			int i = Random.Range (0, puntosDeSpawn.Length);
			this.gameObject.transform.position = puntosDeSpawn [i].transform.position;
			barraVida.value = 10;
		}
		if (vecesQueMurio >= 3) {
			camaraDeSeguimiento.transform.parent = null;
			vidas.text = vidasRestantes.ToString();
			barraVida.gameObject.SetActive (false);
			victoriaODerrota.text = "PERDISTE";
			this.gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (teclaParaReiniciar)) {
			SceneManager.LoadScene (escena.name);
		}
		if (vidaEnemigo.value == 0) {
			muertesEnemigo++;
			if (muertesEnemigo == 3) {
				victoriaODerrota.text = "GANASTE";
			}
		}
	}
}
