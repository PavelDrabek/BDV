using UnityEngine;
using System.Collections;

public class BoneTrap : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.collider.name.ToLower().Contains("grasssprite")) {
			StartCoroutine(StartDestroying());
		}
	}

	IEnumerator StartDestroying() {
		yield return new WaitForSeconds(2);

		Destroy(gameObject);
	}
}
