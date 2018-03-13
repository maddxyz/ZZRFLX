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

		wait = start;
	}
	
	// Update is called once per frame
	void Update () {
		if (wait <= 0) {
			Instantiate (projectile, transform.position, Quaternion.identity);
			wait = start;
		} else {
			wait -= Time.deltaTime;
		}
	}
}
