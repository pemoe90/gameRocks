using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioTamañoPU : MonoBehaviour {

	Vector3 scale;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		Destroy (gameObject);
		cambioTam();
	}

	//cambio el tamaño de los enemigos a la mitad
	void cambioTam(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemies){
			scale = enemy.transform.localScale;
			scale.x = scale.x / 2;
			scale.y = scale.y / 2;
			enemy.transform.localScale = scale;
		}
	}
}
