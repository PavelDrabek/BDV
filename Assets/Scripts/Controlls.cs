using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controlls : MonoBehaviour, IUpdateStatsListener {

	PlayerController player;

	public Text bonesCount;

	void Start() {
		player = FindObjectOfType<PlayerController>();
		if(player) {
			Debug.Log("player found");
			player.AddUpdateListener(this);
		} else {
			Debug.LogWarning("player NOT found");
		}
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			MoveLeft(true);
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow)) {
			MoveLeft(false);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			MoveRight(true);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow)) {
			MoveRight(false);
		}
	}

	public void MoveRight(bool can) {
		player.MovingRight = can;
	}

	public void MoveLeft(bool can) {
		player.MovingLeft = can;
	}

	public void Mute(bool mute) {
		AudioSource source = FindObjectOfType<AudioSource>();
		source.mute = mute;
	}

	public void ThrowBone() {
		player.ThrowBone();
	}

	public void UpdateStats () {
		bonesCount.text = player.bones.ToString() + "x";
	}
}
