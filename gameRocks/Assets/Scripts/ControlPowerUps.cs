using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPowerUps : MonoBehaviour {
	float controladorTiempoPowerUp = 0f; 
	int tiempoPowerUp; //cada cuanto se lanza el powerup

	public GameObject[] tipos;

	public GameObject controladorGO;
	public Control controladorScript;

	public GameObject powerUpGO; //power up seleccionado
	// Use this for initialization
	void Start () {
		//tiempoPowerUp = Random.Range(15, 45);
		tiempoPowerUp = 4;
		controladorGO = GameObject.Find ("Controlador");
		controladorScript = controladorGO.GetComponent<Control> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(controladorScript.nuevoPowerUp){
			controladorTiempoPowerUp += Time.deltaTime;

			if(controladorTiempoPowerUp >= tiempoPowerUp){

				lanzarPowerUp ();
			}
		}

	}

	void lanzarPowerUp(){
		controladorTiempoPowerUp = 0f;
		//tiempoPowerUp = Random.Range(15, 45);
		tiempoPowerUp = 4;
		Vector3 posicion = new Vector3 (Random.Range (-7.0f, 7.0f), Random.Range (-4.0f, 4.0f), 0);
		int select = Random.Range (0, tipos.Length);
		powerUpGO = tipos [select];
		Instantiate (powerUpGO, posicion, Quaternion.identity);
	}
}
