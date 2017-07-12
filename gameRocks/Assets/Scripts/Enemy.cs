using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

	public Vector2 speed = new Vector2(5,5);
	public Vector2 direction = new Vector2(-1, 1);
	public float espacio = 0.6f;

	bool cambiotam = true; //variable para controlar si se le puede cambiar la escala o no
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	// Update is called once per frame
	void Start(){
		cambioVelocidad();
		cambioDireccion ();
	}

	void Update () {
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate()
	{
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();
		rigidbodyComponent.velocity = movement;
	}


	public bool getCambioTam(){
		return cambiotam;
	}

	public void setCambioTam(bool x){
		cambiotam = x;
	} 
	void cambioVelocidad(){
		
		int random = Random.Range(5,10);
		speed.x = random;

		random = Random.Range(5, 10);
		speed.y = random;
	}

	void cambioDireccion(){
		int[] numbers = new int[] {-1,1};
		int random;
		random = numbers[Random.Range (0,100) % 2];
		direction.x = random;

		random = numbers[Random.Range (0,100) % 2];
		direction.y = random;
	}

	void OnCollisionEnter2D(Collision2D objeto){
		if (objeto.gameObject.tag == "Top") {
			direction.y = -1 * direction.y;		
		}

		if (objeto.gameObject.tag == "Bot") {
			direction.y = -1 * direction.y;		
		}

		if (objeto.gameObject.tag == "Right") {
			direction.x = -1 * direction.x;		
		}

		if (objeto.gameObject.tag == "Left") {
			direction.x = -1 * direction.x;		
		}
	}
}
