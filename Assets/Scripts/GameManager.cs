using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }

	void Awake () {
		instance = this;
		DontDestroyOnLoad(gameObject);
		Application.LoadLevel(1);
	}

	void Start () {

	}

	public void LoadLevel() {
		Application.LoadLevel(2);
	}

}
