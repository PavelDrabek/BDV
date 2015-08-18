using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {

	public List<Transform> movingObjects;
	public SpriteRenderer groundPrefab;
	public SpriteRenderer bonePrefab;

	public float generatedToPosition;
	public float generateForwardValue;

	// Use this for initialization
	void Start () {
		generatedToPosition = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float maxX = float.MinValue;
		foreach(Transform t in movingObjects) {
			if(maxX < t.position.x) {
				maxX = t.position.x;
			}
		}

		while(generatedToPosition < maxX + generateForwardValue) {
			CreateGround();
		}
	}

	private void CreateGround() {
		SpriteRenderer ground = Instantiate(groundPrefab);
		float groundSize = groundPrefab.bounds.size.x;
		generatedToPosition += groundSize;

		ground.transform.position = new Vector3(generatedToPosition, 0, 0);
		ground.transform.SetParent(transform);

		if(Random.Range(0,3) == 0) {
			SpriteRenderer bone = Instantiate(bonePrefab);
			bone.transform.position = new Vector3(generatedToPosition + Random.Range(-groundSize/2, groundSize/2), -1, 0);
			bone.transform.SetParent(transform);
		}
	}
}
