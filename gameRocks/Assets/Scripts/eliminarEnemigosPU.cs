//Script del power up que elimina la mitad de enemigos
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminarEnemigosPU : MonoBehaviour {

	public GameObject controladorGO;
	public ControladorRocas controladorScript;
	// Use this for initialization
	void Start () {
		controladorGO = GameObject.Find ("Controlador");
		controladorScript = controladorGO.GetComponent<ControladorRocas> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		Destroy (gameObject);
		eliminar ();
	}

	//funcion eliminar mitad de enemigos
	void eliminar (){
		int cont = 0;
		int size = controladorScript.goList.Count / 2;
		for(cont = 0; cont < size; cont++){
			Destroy (controladorScript.goList [0]);
			controladorScript.goList.Remove (controladorScript.goList [0]);
		}

	}
}
