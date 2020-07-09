using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Bullet bullet;
	public AudioSource fire;
	public AudioSource load;
	public Sprite on;
	public Sprite off;
	public bool firing = false;
	public float time = 1.0f;
	private float timer = .5f;
	// Use this for initialization
	void Start () {
		timer = time;
	}

	void Fire()
	{
		Bullet bulletClone = (Bullet) Instantiate(bullet, transform.position + new Vector3(0,0,1), transform.rotation);
		fire.Play ();
	}

	void Clamp()
	{
		if (transform.position.x > 3.5) {
			transform.position = new Vector3(3.5f,transform.position.y,transform.position.z);
		}

		if (transform.position.x < -3.5) {
			transform.position = new Vector3(-3.5f,transform.position.y,transform.position.z);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position = transform.position + new Vector3 (10.0f*Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			transform.position = transform.position + new Vector3 (-10.0f*Time.deltaTime, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (!firing) {
				firing = true;
				timer = time;
				load.Play ();
				SpriteRenderer spr = (SpriteRenderer)this.GetComponent (typeof(SpriteRenderer));
				spr.sprite = on;
			}
		}

		if (firing) {
			timer -= Time.deltaTime;
		}

		if (timer < 0) {
			Fire ();
			firing = false;
			SpriteRenderer spr = (SpriteRenderer)this.GetComponent (typeof(SpriteRenderer));
			spr.sprite = off;
			timer = time;
		}

		Clamp();

	}
}
