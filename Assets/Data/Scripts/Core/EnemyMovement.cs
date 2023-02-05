using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : GenericCharacterMovementScript
{
    public static event Action OnEnemyDied = () => {}; // notify WaveManager
    public void Awake()
    {
        
    }
    public void Start()
    {
        fireTimer = UnityEngine.Random.Range(0f, 1f);
        salvoTimer = UnityEngine.Random.Range(0f, 1f);
        AIManager.instance.AddEnemy(this);
    }

    public NavMeshAgent agent;
    public Transform target;

    public override void Move()
    {
        agent.enabled = true;
        NavMeshPath newPath = new NavMeshPath();
        agent.CalculatePath(target.position, newPath);
        agent.enabled = false;
        if (newPath != null)
        {
            if (newPath.corners.Length > 1)
            {
                Vector3 movementDirection = newPath.corners[1] - transform.position; // Look at the point
                movementDirection = new Vector3(movementDirection.x, 0,movementDirection.z);

                moveX = movementDirection.x;
                moveY = movementDirection.z;
            }
        }
        base.Move();
    }

    public override void FiringInput()
    {
        firing = true;
    }

    public override void Look()
    {
        shootingDirection.LookAt(PlayerMovementScript.instance.transform.position); // Look at the point
        shootingDirection.rotation = Quaternion.Euler(new Vector3(0, shootingDirection.rotation.eulerAngles.y, 0)); // Clamp the x and z rotation
    }

    public override void Death()
    {
        OnEnemyDied.Invoke(); // notifies WaveManager of death
        AIManager.instance.RemoveEnemy(this);
    }
}
