using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAnim : MonoBehaviour {

	public float speed;

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

        exp = GetComponent<ParticleSystem>();

        //target = new Vector2 (player.position.x-150, player.position.y);

        /* Utilisation du théorème de Thalès pour calculer y */
        float y = Mathf.Abs((firePoint.position - groundBC.position).y)
                    + Mathf.Abs((firePoint.position - leftBC.position).x)
                            * (Mathf.Abs((player.position - groundBC.position).y) - Mathf.Abs((firePoint.position - groundBC.position).y))
                            / (Mathf.Abs((player.position - firePoint.position).x));

        //target = new Vector2 (leftBC.position.x, player.position.y);
        target = new Vector2(leftBC.position.x, groundBC.position.y + y);
    }
	
	// Update is called once per frame
	void Update () {
        //if(!exp.isPlaying)
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
