﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAnim : MonoBehaviour {

	public float speed = 5.0f;

	private Transform player;
    private Transform leftBC;
    private Transform firePoint;
    private Transform groundBC;
    private ParticleSystem exp;

	private Vector2 target;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        leftBC = GameObject.FindGameObjectWithTag("LeftBC").transform;
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        groundBC = GameObject.FindGameObjectWithTag("GroundBC").transform;

        /* Utilisation du théorème de Thalès pour calculer y */
        float y = Mathf.Abs((transform.position - groundBC.position).y)
                    + Mathf.Abs((transform.position - leftBC.position).x)
                            * (Mathf.Abs((player.position - groundBC.position).y) - Mathf.Abs((transform.position - groundBC.position).y))
                            / (Mathf.Abs((player.position - transform.position).x));

        if(transform.position.x > player.position.x)
            target = new Vector2(leftBC.position.x, groundBC.position.y + y);
        else
            target = new Vector2(-leftBC.position.x, groundBC.position.y + y);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y) {
			DestroyProjectile ();
		}

        if(GameObject.FindGameObjectWithTag("Player"))
        {
            if (Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 1.0f)
            {
                Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                p.DamagePlayer(20);
                Destroy(gameObject);

            }
        }
	}

	void OnTriggerEnter2D(Collider2D o){
		if (o.CompareTag ("Player")) {
			
        }
	}

	void DestroyProjectile (){
		Destroy (gameObject);
	}
}
