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

	float tiempo = 0f;
	float respawn = 5f;
	float tiempoTotal = -5f;

	public int seg = 0;

	public bool funcionamiento = true; //controla que el juego este corriendo o no

	bool nuevoLanzador = true;
	public bool nuevoPowerUp = true; //para seguir poniendo PU

	public Text txtTiempo;
	public Text txtFinal;
	bool estadoJuego = false; //false parado, true andando
	// Use this for initialization
	void Start () {
		playerGO = GameObject.Find ("Player");
		Playerscript = playerGO.GetComponent<Player> ();

		estadoJuego = true;
		txtTiempo.text = "0";
		//panelFinalGO.SetActive (false);
		escogerLanzador();



	}
	
	// Update is called once per frame
	void Update () {
		if((estadoJuego) && (Playerscript.vivo)){
			nuevoPowerUp = true;
			funcionamiento = true;
			cronometro ();
			tiempo += Time.deltaTime;

			if(nuevoLanzador == true){
				escogerLanzador ();
			}
			if(tiempo >= respawn){
				lanzarRoca ();
			}


		}

		if(Playerscript.vivo == false){
			nuevoPowerUp = false;
			funcionamiento = false;
			reiniciar ();
			estadoJuego = false;
			panelFinalGO.SetActive (true);
			txtFinal.text = "Has durado " + seg.ToString () +"s";
		}
	}



	void borrarRocas(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemies)
			GameObject.Destroy(enemy);
	}

	void borrarPowerUps(){
		GameObject[] powerUp = GameObject.FindGameObjectsWithTag ("PowerUp");
		foreach (GameObject pu in powerUp)
			GameObject.Destroy (pu);
	}

	void reiniciar(){
		borrarRocas ();
		borrarPowerUps ();
		playerGO.transform.position = new Vector3 (0, 0, 0);
		tiempo = 0f;
		estadoJuego = false;
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
		int select = Random.Range (0, lanzadores.Length);
		lanzadorGO = lanzadores [select];
		lanzadorScript = lanzadorGO.GetComponent<LanzarRoca> ();
		lanzadorGO.SetActive (true);
		
	}

	void cronometro(){
		tiempoTotal += Time.deltaTime;

		seg = (int)tiempoTotal % 60;
		txtTiempo.text = seg.ToString ();
	}
		
}
