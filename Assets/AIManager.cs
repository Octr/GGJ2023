using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager instance;

    List<EnemyMovement> enemies = new List<EnemyMovement>();

    public void Awake()
    {
        instance = this;
    }

    public void AddEnemy(EnemyMovement newEnemy)
    {
        enemies.Add(newEnemy);
        UpdatePositioning();
    }

    public void RemoveEnemy(EnemyMovement newEnemy)
    {
        enemies.Remove(newEnemy);
        UpdatePositioning();
    }

    public void UpdatePositioning()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (i <= 3)
            {
                enemies[i].target = PlayerMovementScript.instance.relativePositioningTargets[0];
            }
            else if (i <= 6)
            {
                enemies[i].target = PlayerMovementScript.instance.relativePositioningTargets[1];
            }
            else if (i <= 9)
            {
                enemies[i].target = PlayerMovementScript.instance.relativePositioningTargets[2];
            }
            else if (i <= 12)
            {
                enemies[i].target = PlayerMovementScript.instance.relativePositioningTargets[3];
            }
            else
            {
                enemies[i].target = PlayerMovementScript.instance.transform;
            }
        }
    }
}
