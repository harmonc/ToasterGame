using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    private float timer = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f) {
            Fire();
            timer = 2.0f;  
        }
    }

    void Fire() {
        Instantiate(bullet, new Vector3(transform.position.x,transform.position.y,transform.position.z+1), transform.rotation);
    }
}
