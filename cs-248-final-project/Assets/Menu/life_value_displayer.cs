using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_value_displayer : MonoBehaviour {
	private float percentLifeValueLeft = 100f;
	private Vector3 originalScale;
	private Vector3 originalPosition;
	private float originalWidth;
	// Use this for initialization
	void Start () {
		originalScale = transform.localScale;
		originalPosition = transform.position;
		originalWidth = GetComponent<Collider> ().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.D)){
			if (percentLifeValueLeft < 10f) {
				return;
			}
			receivedAttack (5.0f);
		}
	}

	public void receivedAttack(float attack){
		percentLifeValueLeft -= attack;
		Vector3 newScale = new Vector3 (originalScale.x * percentLifeValueLeft / 100.0f, originalScale.y, originalScale.z);
		Vector3 newPosition = new Vector3 (originalPosition.x -( originalWidth / 2.0f * (100-percentLifeValueLeft) / 100.0f), originalPosition.y, originalPosition.z);
		transform.localScale = newScale;
		transform.position = newPosition;
	}

}
