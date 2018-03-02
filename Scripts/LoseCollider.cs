using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start() {
		//find object of LevelManager for Prefab LoseCollider
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		levelManager.LoadLevel ("Lose Screen");
	}
}
