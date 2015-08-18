using UnityEngine;
using System.Collections;

public class MoveUpAndDown : MonoBehaviour {

	Transform myTransform;
	Vector3 startPosition;
	float time;

	public float speed = 10;
	public float height = 0.05f;

	void Start() {
		myTransform = transform;
		startPosition = myTransform.position;
		time = Time.realtimeSinceStartup;
	}

	// Update is called once per frame
	void Update () {
		myTransform.position = startPosition + new Vector3(0, Mathf.Sin(time + Time.realtimeSinceStartup * speed) * height, 0);
	}
}
