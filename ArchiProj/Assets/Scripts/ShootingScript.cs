using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {

	private float wait; // time between shots;
	public float start; // start time between shots;
	public GameObject projectile;
	private Transform player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;

        Invoke("AddProjectile", Random.Range(2f, 4f));
	}
	

    void AddProjectile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        Invoke("AddProjectile", Random.Range(2f, 4f));
    }
}
