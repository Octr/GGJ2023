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
    /// 2. 👌 create waves of enemies - enemy count increases with wave count - communitate with roots manager to find spawn point
    /// 3. 👌 notify enemies of how many waves have been defeated to scale their difficulty 
    /// 4. 👌 detect when waves are over - sub to OnDestroy event of enemies 
    /// 5. 👌 be able to notify others when there is an active wave - via public variable, not event yet 
    /// </summary>

    public static event Action<bool> OnWaveStatusChange = (waveIsActive) => {};
    
    [Header("Enemy Data")]
    [SerializeField] private GameObject[] m_enemies;
    [SerializeField] private int m_enemySpawnCount = 2;
    
    [Header("Enemy Wave Data")]
    [SerializeField] private int m_wavesDefeated = 0;
    public bool WaveIsActive => m_waveIsActive;
    private bool m_waveIsActive = false;
    private int m_activeEnemyCount = 0;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        EnemyMovement.OnEnemyDied += OnEnemyDied;
        Upgrader.OnPowerUpSelected += OnPowerUpSelected;
        
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
            // going to need to communicate with RootsManager to get location to spawn enemies 
            // will also modify difficulty of enemies (or have enemies modify themselves with ref to m_wavesDefeated)
            Instantiate(m_enemies[0]);
            Debug.Log("Increase enemy difficulty sliders");
        }
        // active enemies same as spawned enemies at beginning 
        m_activeEnemyCount = m_enemySpawnCount;
        
        Debug.Log("Increase enemies that will spawn next time");
        m_enemySpawnCount = m_enemySpawnCount * 2;
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

    private void OnGUI()
    {
        GUI.color = Color.red;
        GUILayout.Label($"Waves defeated : {m_wavesDefeated}");
    }
}
