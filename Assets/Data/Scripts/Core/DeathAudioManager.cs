using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] m_deathClips;
    [SerializeField] private AudioSource m_audioSource;
    
    private void OnValidate()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        EnemyMovement.OnEnemyDied += PlayEnemyDeathSound;
        HeartManager.OnPlayerDied += PlayPlayerDeathSound;
    }

    private void OnDisable()
    {
        EnemyMovement.OnEnemyDied -= PlayEnemyDeathSound;
        HeartManager.OnPlayerDied -= PlayPlayerDeathSound;

    }

    private void PlayEnemyDeathSound()
    {
        m_audioSource.clip = m_deathClips[0];
        m_audioSource.Play();
    }

    private void PlayPlayerDeathSound()
    {
        m_audioSource.clip = m_deathClips[1];
        m_audioSource.Play();
    }
}
