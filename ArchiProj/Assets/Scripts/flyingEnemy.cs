using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemy : MonoBehaviour {

    private float wait;
    public float start;
    public GameObject enemy;

    // Use this for initialization
    void Start ()
    {
        wait = start;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (wait <= 0)
        {
            Instantiate(enemy, new Vector2(Random.Range(GameObject.FindGameObjectWithTag("LeftBC").transform.position.x, GameObject.FindGameObjectWithTag("RightBC").transform.position.x), transform.position.y), Quaternion.identity);
            wait = start;
        }
        else
        {
            wait -= Time.deltaTime;
        }
    }
}
