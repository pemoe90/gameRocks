using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float velocidad = 10.0f;
	public float espacio = 0.6f;

	public bool vivo = true; // 0 está vivo
	public Vector3 pos;

	float tiempoInvulnerable = 5f; // tiempo que esta invulnerable

	private CircleCollider2D playerCollider;
	// Use this for initialization
	void Start () {
		playerCollider = gameObject.GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movimiento ();
	}

	void OnCollisionEnter2D(Collision2D objeto){
		if (objeto.gameObject.tag == "Enemy") {
			vivo = false;
		}
	}

	void movimiento(){
		transform.Translate (Input.GetAxis ("Horizontal") * velocidad * Time.deltaTime, Input.GetAxis ("Vertical") * velocidad * Time.deltaTime, 0);
		mantenerPantalla();
	}

	void mantenerPantalla(){
		Vector3 pos = transform.position;

		if(pos.y + espacio > Camera.main.orthographicSize){
			pos.y = Camera.main.orthographicSize - espacio;
		}

		if(pos.y - espacio < -Camera.main.orthographicSize){
			pos.y = -Camera.main.orthographicSize + espacio;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float anchoOrto = Camera.main.orthographicSize * screenRatio;

		if(pos.x + espacio > anchoOrto){
			pos.x = anchoOrto - espacio;
		}

		if(pos.x - espacio < -anchoOrto){
			pos.x = -anchoOrto + espacio;
		}

		transform.position = pos;
	}
	/*
	public void invulnerabilidad(){
		controladorTiempoInvulnerable = 0f;
		playerCollider.isTrigger = true;

		while(controladorTiempoInvulnerable < tiempoInvulnerable){
			controladorTiempoInvulnerable += Time.deltaTime;

		}

		if(controladorTiempoInvulnerable >= tiempoInvulnerable){
			Debug.Log (controladorTiempoInvulnerable);
			playerCollider.isTrigger = false;
		}

	}
	*/

	public void empezarInvulnerabilidad(){
		StartCoroutine (invulnerabilidad ());	
	}

	public IEnumerator invulnerabilidad (){
		Debug.Log ("Hecho");
		gameObject.layer = 9;
		yield return new WaitForSeconds (tiempoInvulnerable);
		Debug.Log ("TErminado");
		gameObject.layer = 8;
	}
}
