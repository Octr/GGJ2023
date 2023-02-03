using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public static event Action OnEnemyDied = () => {};
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            OnEnemyDied.Invoke();
        }
    }
}
