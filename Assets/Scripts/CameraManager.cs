using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Transform cameraTransform;

	PlayerController player;
	
	void Start() {
		player = FindObjectOfType<PlayerController>();
		if(player) {
			Debug.Log("player found");
		} else {
			Debug.LogWarning("player NOT found");
		}
	}

	void Update () {
		CameraUpdate();
	}
	
	void CameraUpdate() {
		if(cameraTransform != null) {
			Vector3 pos = cameraTransform.position;
			pos.x = player.transform.position.x;
			cameraTransform.position = pos;
		}
	}
}
