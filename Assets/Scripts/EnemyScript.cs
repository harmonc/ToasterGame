using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public AudioSource explosion;
	public AudioSource coinNoise;
	public GameObject health;
	public float speed;
	public float horizontalSpeed;
	private float dX;
	public GameObject coin;
	public GameObject score;
	// Use this for initialization
	void Start () {
		dX = horizontalSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (dX*Time.deltaTime, speed*Time.deltaTime, 0);
		Bounce ();
		if (transform.position.y < -7) {
			Destroy (this.gameObject);
		}
	}

	void Bounce()
	{
		if (transform.position.x > 4) {
			dX = Mathf.Abs (horizontalSpeed) * -1;
		}
		else if(transform.position.x < -4) {
			dX = Mathf.Abs(horizontalSpeed);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "bullet") {
			explosion.Play ();
			ScoreScript scoreScript = (ScoreScript)score.GetComponent (typeof(ScoreScript));
			scoreScript.score++;
			if (Random.Range (0.0f, 1.0f) > 0.5f) {
				GameObject newCoin = Instantiate (coin, this.transform.position, this.transform.rotation);
				CoinScript coinScript = (CoinScript)newCoin.GetComponent (typeof(CoinScript));
				coinScript.coinGet = coinNoise;
			}
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
		if (other.tag == "Player") {
			explosion.Play ();
			HealthBar healthbar = (HealthBar)health.GetComponent (typeof(HealthBar));
			healthbar.hit();
			Destroy (this.gameObject);
		}
	}
}
