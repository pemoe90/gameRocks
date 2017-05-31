using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarRoca : MonoBehaviour {
	public GameObject rock;

	public void crearRoca(){
		GameObject enemy = Instantiate (rock, transform.position, transform.rotation) as GameObject; 
	}
}
