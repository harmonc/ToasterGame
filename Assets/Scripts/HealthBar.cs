using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public GameObject hp;
	public GameObject gameOver;
	Stack hps = new Stack();
	// Use this for initialization
	void Start () {
		GameObject hp1 = (GameObject) Instantiate(hp, transform.position + new Vector3(-0.3f,0.065f,0), transform.rotation);	
		hp1.transform.SetParent(this.transform);
		GameObject hp2 = (GameObject) Instantiate (hp, transform.position + new Vector3 (0.6f, 0.065f, 0), transform.rotation);
		hp2.transform.SetParent (this.transform);
		GameObject hp3 = (GameObject) Instantiate (hp, transform.position + new Vector3 (1.5f, 0.065f, 0), transform.rotation);
		hp3.transform.SetParent (this.transform);
		hps.Push (hp1);
		hps.Push (hp2);
		hps.Push (hp3);
	}

	public void hit(){
		GameObject nextHp = (GameObject)hps.Pop ();
		Destroy (nextHp);
		if (hps.Count == 0) {
			Instantiate(gameOver, new Vector3 (0, 0, 0), transform.rotation);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
