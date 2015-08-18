using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogController : MonoBehaviour {

	public Transform myTransform;
	public Animator animator;
	
	public float speed;
	public float minZone;
	public float maxZone;

	public List<Transform> dangerousObjects = new List<Transform>();

	private float actualVelocity;

	// Use this for initialization
	void Start () {
		StartCoroutine(CheckDanger());
	}
	
	// Update is called once per frame
	void Update () {
//		float closestDanger = float.MaxValue;
//		foreach(Transform danger in dangerousObjects) {
//			float dist = Vector3.Distance(myTransform.position, danger.position);
//			if(dist < closestDanger){
//				closestDanger = dist;
//			}
//		}
//
//		if(closestDanger < 3) {
//			Debug.Log("closest danger is " + closestDanger);
//			RunAway(dangerousObjects[0].position);
//		} else {
//			animator.SetFloat("Speed", 0);
//		}

		transform.localPosition += new Vector3(actualVelocity * Time.deltaTime, 0, 0);
		
		/*
		 * Udelat stavy - UpdateEating(), UpdateWaiting(), UpdateRunning(), ...
		 */
	}

	IEnumerator CheckDanger() {
		while(true) {
			float dist = Vector3.Distance(transform.position, dangerousObjects[0].position);
			if(dist < minZone) {
				RunAway(dangerousObjects[0].position);
			} else {
				if(dist > maxZone) {
					SetVelocity(0);
				}
			}

			yield return 1;
		}
	}

	void RunAway(Vector3 dangerous) {
		float vect = myTransform.position.x - dangerous.x;
		float dir = vect / Mathf.Abs(vect); // 1 or -1
		SetVelocity(dir * speed);
	}

	void SetVelocity(float velocity) {
		actualVelocity = velocity;
		animator.SetFloat("Speed", velocity);
	}

//	void OnTriggerEnter2D(Collider2D c) {
//		Debug.Log("adding... haf!");
//		dangerousObjects.Add(c.transform);
//		RunAway(c.transform.position);
//	}
//	
//	void OnTriggerExit2D(Collider2D c) {
//		Debug.Log("removing haf! 2");
//		dangerousObjects.Remove(c.transform);
//		SetVelocity(0);
//	}
}
