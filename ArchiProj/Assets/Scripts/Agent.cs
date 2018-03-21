using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Agent : MonoBehaviour {

    private Transform player;
    private PlatformerCharacter2D ctrl;
    bool canJump = true;
    float lastJump = 0;
    // Use this for initialization
    void Start ()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        ctrl = player.GetComponent(typeof(PlatformerCharacter2D)) as PlatformerCharacter2D;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Projectile"))
        {
            Transform projectile = GameObject.FindGameObjectWithTag("Projectile").transform;
            float distanceToTarget = Vector2.Distance(player.position,
                                              projectile.position);

            if (distanceToTarget < 2.0f && lastJump > 1.0 && Mathf.Abs((projectile.position - player.position).y) < 1.0f)
            {
                ctrl.Move(0, false, true);
                lastJump = 0;
            }
                
        }
        lastJump += Time.deltaTime;
	}
}
