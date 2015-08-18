using UnityEngine;
using System.Collections;

public class CheckFirstScene : MonoBehaviour {

	void Awake () {
		if(GameManager.Instance == null) {
			Application.LoadLevel(0);
		}
	}
}
