using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotateScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 150.0f*Time.deltaTime, 0));
	}
}
