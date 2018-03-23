using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemy : MonoBehaviour {

    private float wait;
    public float start;
    public GameObject enemy;
    public GameObject EnemySpaceship;



    // Use this for initialization
    void Start ()
    {
        Invoke("AddFlyingEnemy", 20);
        Invoke("AddSpaceship", 40);
    }

    void AddFlyingEnemy()
    {
        Instantiate(enemy, new Vector2(Random.Range(GameObject.FindGameObjectWithTag("LeftBC").transform.position.x, GameObject.FindGameObjectWithTag("RightBC").transform.position.x), transform.position.y), Quaternion.identity);
        Invoke("AddFlyingEnemy", 2);
    }
    void AddSpaceship()
    {
        Instantiate(EnemySpaceship, new Vector2(Random.Range(GameObject.FindGameObjectWithTag("LeftBC").transform.position.x, GameObject.FindGameObjectWithTag("RightBC").transform.position.x), 0f), Quaternion.identity);
    }
}
