using System;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
   // public static event Action OnEnemyDied = () => {};
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Oh no I'm deeeaaaaddd");
          //  OnEnemyDied.Invoke();
            Destroy(gameObject);
        }
    }
}
