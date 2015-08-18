using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour {

	void Start() {
		StartButtonClick();
	}

	public void StartButtonClick() {
		GameManager.Instance.LoadLevel();
	}
}
