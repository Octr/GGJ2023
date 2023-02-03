using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    /// <summary>
    /// 1. 👌 keeps track of how many waves have been defeated
    /// 2. create waves of enemies - enemy count increases with wave count - communitate with roots manager to find spawn point
    /// 3. notify enemies of how many waves have been defeated to scale their difficulty 
    /// 4. 👌 detect when waves are over - sub to OnDestroy event of enemies 
    /// 5. 👌 be able to notify others when there is an active wave - via public variable, not event yet 
    /// </summary>
    
    [Header("Enemy Data")]
    [SerializeField] private GameObject[] m_enemies;
    [SerializeField] private int m_enemySpawnCount = 1;
    
    [Header("Enemy Wave Data")]
    [SerializeField] private int m_wavesDefeated = 0;
    public bool WaveIsActive => m_waveIsActive;
    private bool m_waveIsActive = false;
    private int m_activeEnemyCount = 0;
    
    private void Start()
    {
        SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
        TestEnemy.OnEnemyDied += TestEnemyOnOnEnemyDied;
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;
        TestEnemy.OnEnemyDied -= TestEnemyOnOnEnemyDied;
    }
    
    // going to reset all our variables when scene reloads (or when level lost)
    private void SceneManagerOnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        m_wavesDefeated = 0;
        m_enemySpawnCount = 1;
    }
    
    // when enemy dies, decrease activeEnemyCount
    private void TestEnemyOnOnEnemyDied()
    {
        m_activeEnemyCount--;

        if (m_activeEnemyCount == 0)
        {
            OnWaveDefeated();
        }
    }

    private void OnWaveDefeated()
    {
        m_waveIsActive = false;
        m_wavesDefeated++;
        // probably going to be other stuff such as creating downtime and allowing power upgrades 
    }
}
