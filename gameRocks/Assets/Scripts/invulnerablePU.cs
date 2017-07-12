using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invulnerablePU : MonoBehaviour {
	public GameObject playerGO;
	public Player playerScript;
	// Use this for initialization
	void Start () {
		playerGO = GameObject.Find ("Player");
		playerScript = playerGO.GetComponent<Player>();
	}

	void OnCollisionEnter2D(Collision2D col){
		Destroy (gameObject);
		invulneravilidad ();
	}

	void invulneravilidad(){
		playerScript.empezarInvulnerabilidad ();
	}
}
