using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemyMove : MonoBehaviour {

    public float speed = 5.0f;
    private Transform player;
    private Vector2 target;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }

        if(GameObject.FindGameObjectWithTag("Player"))
        {
            if (Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 1.0f)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
