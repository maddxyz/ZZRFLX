using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAnim : MonoBehaviour {

	public float speed;

	private Transform player;
	private Vector2 target;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		//target = new Vector2 (player.position.x-150, player.position.y);
		target = new Vector2 (player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);

		if (transform.position.x == target.x && transform.position.y == target.y) {
			DestroyProjectile ();
		}

	}

	void OnTriggerEnter2D(Collider2D o){
		if (o.CompareTag ("Player")) {
			DestroyProjectile ();
		}
	}

	void DestroyProjectile (){
		Destroy (gameObject);
	}
}
