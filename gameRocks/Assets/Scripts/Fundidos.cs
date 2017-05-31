using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundidos : MonoBehaviour {

	//public Image fundido;
	public string[] escenas;
	// Use this for initialization
	void Start () {
		//fundido.CrossFadeAlpha (0, 0.5f, false);		
	}

	public void FadeOut(int s){
		//fundido.CrossFadeAlpha (1, 0.5f, false);
		StartCoroutine (CambioEscena (escenas [s]));
	}

	public void Exit(){
		Application.Quit ();
	}

	IEnumerator CambioEscena(string escena){
		yield return new WaitForSeconds (0);
		SceneManager.LoadScene (escena);
	}

}
