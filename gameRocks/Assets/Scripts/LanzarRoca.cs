using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarRoca : MonoBehaviour {
	

	public GameObject controladorGO;
	public ControladorRocas controladorScript;
	public GameObject rock;

	void Start(){
		controladorGO = GameObject.Find ("Controlador");
		controladorScript = controladorGO.GetComponent<ControladorRocas> ();
	}
	public void crearRoca(){
		GameObject enemy = Instantiate (rock, transform.position, transform.rotation) as GameObject; 
		controladorScript.goList.Add (enemy);
	}
}
