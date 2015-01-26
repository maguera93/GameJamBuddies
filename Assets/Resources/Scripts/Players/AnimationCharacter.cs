using UnityEngine;
using System.Collections;

public class AnimationCharacter : MonoBehaviour {
	
	// VARIABLE PRIVADA DE TIPO ANIMATION
	public Animation anim;
	
	// Use this for initialization
	void Start () {
		// COGEMOS SU COMPONENTE ANIMATION DEL GAMEOBJECT DONDE ESTA

		anim = transform.FindChild("character_animations").GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// ANIMACION DE SALTO
	public void setJump(){
		// REPRODUCIR LA ANIMACION DE SALTO
		anim.Play ("Jump");
	}
	
	// ANIMACION DE CORRER HACIA LA DERECHA
	public void setRunRight(){
		// REPRODUCIMOS LA ANIMACION DE CORRER
		anim.Play ("Run");
		// GIRAMOS SU MESH 90º
		//transform.eulerAngles = new Vector3 (0, 90, 0);
	}
	
	// ANIMACION DE CORRER HACIA LA IZQUIERDA
	public void setRunLeft(){
		// REPRODUCIMOS LA ANIMACION DE CORRER
		anim.Play ("Run");
		// GIRAMOS SU MESH 270º
		transform.eulerAngles = new Vector3 (0, 270, 0);
	}
	
	// ANIMACION DE REPOSO
	public void setIdle(){
		// REPRODUCIR LA ANIMACION DE IDLE
		anim.Play ("Idle");
	}

	public void setPush(){
		anim.Play ("Push");

		}
}