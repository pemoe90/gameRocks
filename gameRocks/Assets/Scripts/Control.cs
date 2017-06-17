using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {

	public GameObject[] lanzadores;

	public GameObject lanzadorGO;
	public LanzarRoca lanzadorScript;

	public GameObject playerGO;
	public Player Playerscript;

	public GameObject panelFinalGO;

	public GameObject powerUpGO;

	float tiempo = 0f;
	float respawn = 5f;
	float tiempoTotal = -5f;
	float controladorTiempoPowerUp = 0f;
	int tiempoPowerUp;
	public int seg = 0;

	bool nuevoLanzador = true;

	public Text txtTiempo;
	public Text txtFinal;
	int estadoJuego = 0; //0 parado 1 andando
	// Use this for initialization
	void Start () {
		playerGO = GameObject.Find ("Player");
		Playerscript = playerGO.GetComponent<Player> ();

		estadoJuego = 1;
		txtTiempo.text = "0";
		//panelFinalGO.SetActive (false);
		escogerLanzador();

		tiempoPowerUp = 5;
		//tiempoPowerUp = Random.Range(15, 45);
	}
	
	// Update is called once per frame
	void Update () {
		if((estadoJuego == 1) && (Playerscript.muerto == 0)){
			cronometro ();
			tiempo += Time.deltaTime;
			controladorTiempoPowerUp += Time.deltaTime;
			if(nuevoLanzador == true){
				escogerLanzador ();
			}
			if(tiempo >= respawn){
				lanzarRoca ();
			}

			if(controladorTiempoPowerUp >= tiempoPowerUp){
				
				lanzarPowerUp ();
			}
		}

		if(Playerscript.muerto == 1){
			reiniciar ();
			estadoJuego = 0;
			panelFinalGO.SetActive (true);
			txtFinal.text = "Has durado " + seg.ToString () +"s";
		}

		if (Input.GetKeyDown ("space") && (Playerscript.muerto == 1)) {
			Playerscript.muerto = 0;
			estadoJuego = 1;
			lanzarRoca ();
		}
	}



	void borrarRocas(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemies)
			GameObject.Destroy(enemy);
	}

	void reiniciar(){
		borrarRocas ();
		playerGO.transform.position = new Vector3 (0, 0, 0);
		tiempo = 0f;
		estadoJuego = 0;
		tiempoTotal = 0f;
		txtTiempo.text = "0";
	}

	void lanzarRoca(){
		nuevoLanzador = true;
		tiempo = 0f;
		lanzadorScript.crearRoca ();
		lanzadorGO.SetActive (false);

	}

	void escogerLanzador(){
		nuevoLanzador = false;
		int select = Random.Range (0, 4);
		lanzadorGO = lanzadores [select];
		lanzadorScript = lanzadorGO.GetComponent<LanzarRoca> ();
		lanzadorGO.SetActive (true);
		
	}

	void cronometro(){
		tiempoTotal += Time.deltaTime;

		seg = (int)tiempoTotal % 60;
		txtTiempo.text = seg.ToString ();
	}

	void lanzarPowerUp(){
		controladorTiempoPowerUp = 0f;
		tiempoPowerUp = Random.Range(15, 45);
		Vector3 posicion = new Vector3 (Random.Range (-8.0f, 8.0f), Random.Range (-4.0f, 4.0f), 0);
		Instantiate (powerUpGO, posicion, Quaternion.identity);
	}
}
