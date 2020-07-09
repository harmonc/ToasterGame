using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	// Use this for initialization
	private float dA;
	public float horizontal = 0;
	void Start () {
		dA = Random.Range (50.0f, 200.0f);
		if (Random.Range (0, 1.0f) > 0.5f) {
			dA *= -1;
		}
		transform.Rotate (new Vector3 (0, 0, Random.Range (0.0f, 500.0f)));
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (horizontal*Time.deltaTime, 7.5f*Time.deltaTime, 0);
		transform.Rotate (new Vector3 (0, 0, dA*Time.deltaTime));
		if (transform.position.y > 5) {
			Destroy(this.gameObject);
		}
	}
}
