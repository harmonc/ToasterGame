using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	public AudioSource coinGet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (0, -5.0f*Time.deltaTime, 0);

		if (transform.position.y < -7) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			coinGet.Play ();
			Debug.Log("Coin!");
			Destroy(this.gameObject);
		}
	}
}
