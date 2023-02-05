using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartManager : SingletonParent<HeartManager>
{
    public static event Action OnPlayerDied = () => { };
    
    [SerializeField] private List<GameObject> m_allHearts;
    [SerializeField] private float m_defaultHealth;
    //[SerializeField] private int m_maxHealth;

    [SerializeField] private GameObject m_heartPrefab;
    [SerializeField] private GenericCharacterMovementScript m_playerMovementScript;

    public bool PlayerIsDead => m_playerIsDead;
    private bool m_playerIsDead = false;
    
    private void Start()
    {
        GenericCharacterMovementScript.OnPlayerDamaged += RemoveHeart;
        m_defaultHealth = m_playerMovementScript.health;
        m_playerIsDead = false;
        
        for (int i = 0; i < m_defaultHealth; i++)
        {
            var spawnedHeart = Instantiate(m_heartPrefab);
            spawnedHeart.transform.parent = transform;
            m_allHearts.Add(spawnedHeart);
        }
    }

    private void OnDisable()
    {
        GenericCharacterMovementScript.OnPlayerDamaged -= RemoveHeart;
    }

    private void RemoveHeart()
    {
        int currentHearts = m_allHearts.Count;
        if (currentHearts <= 0) return;
        GameObject tempHeart = m_allHearts[currentHearts - 1];
        m_allHearts.Remove(tempHeart);
        Destroy(tempHeart);
        
       int currentHearts2 = m_allHearts.Count;
       
       if(m_allHearts.Count <= 0)
       {
           m_playerIsDead = true;
           OnPlayerDied.Invoke(); 
           StartCoroutine(Death());
           //PLAYER IS DYING AND RELOADING THE GAME HERE!
           //SceneManager.LoadScene("NewCharacterTesting");
       }
           
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("NewCharacterTesting");
    }

    /* scope creep lol 
    private void AddHeart()
    {
        int currentHearts = m_allHearts.Count;
        if(currentHearts >= m_maxHealth) return;
        var spawnedHeart = Instantiate(m_heartPrefab);
        spawnedHeart.transform.parent = transform;
        m_allHearts.Add(spawnedHeart);
    }
    */
}

