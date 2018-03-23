using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class SmartAgent : Agent {

    private PlatformerCharacter2D ctrl;

    void Start () {
        ctrl = GetComponent(typeof(PlatformerCharacter2D)) as PlatformerCharacter2D;
    }

    List<float> observation = new List<float>();

    public override void CollectObservations()
    {

        /* Projectiles */

        /* Peut paraitre inutile comme ligne : instancier explicitement un tableau de 0 éléments
         * Mais allége beaucoup la partie code */
        var projectiles = new GameObject[0];
        if(GameObject.FindGameObjectWithTag("Projectile"))
            projectiles = GameObject.FindGameObjectsWithTag("Projectile");

        foreach(var projectile in projectiles)
        {
            Vector2 relativePosition = projectile.transform.position - transform.position;

            AddVectorObs(relativePosition.x);
            AddVectorObs(relativePosition.y);
        }

        if(projectiles.Length <= 1)
        {
            AddVectorObs(500.0f);
            AddVectorObs(500.0f);
        }

        if (projectiles.Length <= 0)
        {
            AddVectorObs(500.0f);
            AddVectorObs(500.0f);
        }

        /* Flying ennemies */
        var enemies = new GameObject[0];
        if (GameObject.FindGameObjectWithTag("Enemy2"))
            projectiles = GameObject.FindGameObjectsWithTag("Enemy2");

        foreach (var enemy in enemies)
        {
            Vector2 relativePosition = enemy.transform.position - transform.position;

            AddVectorObs(relativePosition.x);
            AddVectorObs(relativePosition.y);
        }

        if (enemies.Length <= 1)
        {
            AddVectorObs(500.0f);
            AddVectorObs(500.0f);
        }

        if (enemies.Length <= 0)
        {
            AddVectorObs(500.0f);
            AddVectorObs(500.0f);
        }
        /*if (GameObject.FindGameObjectWithTag("Projectile"))
        {
            
            Vector2 relativePosition = GameObject.FindGameObjectWithTag("Projectile").transform.position - transform.position;

            AddVectorObs(relativePosition.x);
            AddVectorObs(relativePosition.y);
        }
        else
        {
            AddVectorObs(500.0f);
            AddVectorObs(500.0f);
        }     
        */
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        float distanceToTarget;

        if(GameObject.FindGameObjectWithTag("Projectile"))
        {
            var projectiles = GameObject.FindGameObjectsWithTag("Projectile");

            foreach (var projectile in projectiles)
            {
                distanceToTarget = Vector2.Distance(transform.position,
                                                      projectile.transform.position);

                if (distanceToTarget < 1.0f)
                {
                    //Done();
                    AddReward(-1.0f);
                }
            }
        }
        
        if(GameObject.FindGameObjectWithTag("Enemy2"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy2");

            foreach (var enemy in enemies)
            {
                distanceToTarget = Vector2.Distance(transform.position,
                                                      enemy.transform.position);

                if (distanceToTarget < 1.0f)
                {
                    //Done();
                    AddReward(-1.0f);
                }
            }
        }
        
        /*if (GameObject.FindGameObjectWithTag("Projectile"))
            distanceToTarget = Vector2.Distance(transform.position,
                                                  GameObject.FindGameObjectWithTag("Projectile").transform.position);
        else
            distanceToTarget = 500.0f;


        // Reached target
        if (distanceToTarget < 1.0f)
        {
            Done();
            AddReward(-1.0f);
        }
        */
        // Time reward
        AddReward(+0.05f);
        
        /* Doc :
         * 
         * 1) Right
         * 2) Left
         * 3) Jump
         * */

        /* On teste si le joueur dépasse l'écran, test qui n'est pas nécéssaire normalement 
         * mais si on le fait pas l'agent se met à voler très loin */

        if (vectorAction[0] >= vectorAction[1] && vectorAction[0] >= vectorAction[2])
        {
            // 5 correspand à 0.5 * 10 où 10 correspand à maxSpeed on devra changer ca après (ici on teste)
            if(Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("RightBC").transform.position.x) > 5.0)
                ctrl.Move(0.5f, false, false);
            else
                ctrl.Move(Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("RightBC").transform.position.x)/10, false, false);
        }
            
        else if (vectorAction[1] >= vectorAction[0] && vectorAction[1] >= vectorAction[2])
            if (Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("LeftBC").transform.position.x) > 5.0)
                ctrl.Move(-0.5f, false, false);
            else
                ctrl.Move(Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("LeftBC").transform.position.x) / 10, false, false);
        else
            ctrl.Move(0, false, true);

    }
}
