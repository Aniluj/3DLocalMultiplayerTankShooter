using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Botiquin : MonoBehaviour {

    private bool activo;

    private void Start()
    {
        activo = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if(activo)
        {
            Vida vida = col.gameObject.GetComponent<Vida>();
            if(vida != null)
            {
                vida.RegenerarVida(5);
            }
            activo = false;

            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(
                                                                                    this.gameObject.GetComponent<MeshRenderer>().material.color.r,
                                                                                    this.gameObject.GetComponent<MeshRenderer>().material.color.g,
                                                                                    this.gameObject.GetComponent<MeshRenderer>().material.color.b,
                                                                                    0.0f);
            this.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }

}
