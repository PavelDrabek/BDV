using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public Transform myTransform;
	public Transform cameraTransform;
	public Rigidbody2D boneTrapPrefab;
	public float speed;
	public int bones;
	public float throwForce = 5;
	public float throwTorgue = 15;

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
			Rigidbody2D rigid = Instantiate(boneTrapPrefab);
			rigid.transform.position = myTransform.position + new Vector3(0.5f, 1.5f, 0);
			rigid.AddForce(Vector2.one * throwForce, ForceMode2D.Impulse);
			rigid.AddTorque(-throwTorgue);

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
