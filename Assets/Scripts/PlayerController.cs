using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public Transform myTransform;
	public Transform cameraTransform;
	public float speed;
	public int bones;

	private bool _movingLeft;
	private bool _movingRight;

	public bool MovingLeft { get { return _movingLeft; } set { _movingLeft = value; } }
	public bool MovingRight { get { return _movingRight; } set { _movingRight = value; } }

	private List<IUpdateStatsListener> updateListeners = new List<IUpdateStatsListener>();

	void Update () {
		if(MovingLeft) {
			myTransform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		if(MovingRight) {
			myTransform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}

	public void OnTriggerEnter2D(Collider2D c) {
		if(c.tag.Equals("Bone")) {
			Destroy(c.transform.gameObject);
			bones++;
			InformUpdateListeners();
		}
	}

	public void ThrowBone() {
		if(bones > 0) {
			bones--;
			InformUpdateListeners();
		}
	}

	private void InformUpdateListeners() {
		foreach(IUpdateStatsListener l in updateListeners) {
			l.UpdateStats();
		}
	}

	public void AddUpdateListener(IUpdateStatsListener l) {
		updateListeners.Add(l);
	}
}
