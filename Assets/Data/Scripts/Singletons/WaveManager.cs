using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class WaveManager : SingletonParent<WaveManager>
{
    /// <summary>
    /// 1. 👌 keeps track of how many waves have been defeated
    /// 2. 👌 create waves of enemies - enemy count increases with wave count - rotating spawn points
    /// 3. 👌 notify enemies of how many waves have been defeated to scale their difficulty 
    /// 4. 👌 detect when waves are over - sub to OnDestroy event of enemies 
    /// 5. 👌 be able to notify others when there is an active wave - via public variable, not event yet 
    /// </summary>

    public static event Action<bool> OnWaveStatusChange = (waveIsActive) => {};

    [Header("Enemy Data")]
    [SerializeField] private GameObject[] m_enemies;
    [SerializeField] private int m_enemySpawnCount = 2;
    [SerializeField] private Transform[] m_enemySpawnPoints;
    private int m_nextSpawnPoint = 0;
    private int m_maxSpawnPoint = 0;

    [Header("Enemy Wave Data")]
    [SerializeField] private int m_wavesDefeated = 0;

    public int WavesDefeated => m_wavesDefeated;
    public bool WaveIsActive => m_waveIsActive;
    private bool m_waveIsActive = false;
    private int m_activeEnemyCount = 0;

    private int m_enemySpawnIncreaseRate = 0;
    

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        EnemyMovement.OnEnemyDied += OnEnemyDied;
        Upgrader.OnPowerUpSelected += OnPowerUpSelected;

        m_maxSpawnPoint = m_enemySpawnPoints.Length; // maxSpawnPoint = however many spawn points there are
        m_enemySpawnIncreaseRate = 0;

        
        // always start scene with no enemies 
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i].gameObject);
            Debug.Log("destroying objects");
        }
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        EnemyMovement.OnEnemyDied -= OnEnemyDied;
        Upgrader.OnPowerUpSelected -= OnPowerUpSelected;   
    }
    
    // going to reset all our variables when scene reloads (or when level lost)
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        m_wavesDefeated = 0;
        m_enemySpawnCount = 1;
        m_nextSpawnPoint = 0;
        m_enemySpawnIncreaseRate = 0;

        // always start scene with no enemies 
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i].gameObject);
            Debug.Log("destroying objects");
        }
    }
    
    private void OnPowerUpSelected()
    {
        CreateWave();
    }

    private void CreateWave()
    {
        OnWaveStatusChange.Invoke(true);
        m_waveIsActive = true;
        for (int i = 0; i < m_enemySpawnCount; i++)
        {
            // will also modify difficulty of enemies (or have enemies modify themselves with ref to m_wavesDefeated)
            
            // enemy will spawn at a spawnPoints
            Instantiate(m_enemies[0], m_enemySpawnPoints[m_nextSpawnPoint]);
            
            // if next spawn point is same as max -1 bc arrays, reset to 0
            if (m_nextSpawnPoint == m_maxSpawnPoint - 1)
            {
                m_nextSpawnPoint = -1;
            }
            m_nextSpawnPoint++;
        }
        // Debug.Log("Increase enemy difficulty sliders");
        m_activeEnemyCount = m_enemySpawnCount;
        
        m_enemySpawnIncreaseRate++;
        m_enemySpawnCount = m_enemySpawnCount + m_enemySpawnIncreaseRate;
    }

    // when enemy dies, decrease activeEnemyCount
    private void OnEnemyDied()
    {
        m_activeEnemyCount--;

        if (m_activeEnemyCount == 0)
        {
            OnWaveDefeated();
        }
    }

    private void OnWaveDefeated()
    {
        OnWaveStatusChange.Invoke(false);
        m_waveIsActive = false;
        m_wavesDefeated++;
        // probably going to be other stuff such as creating downtime and allowing power upgrades 
    }
}
