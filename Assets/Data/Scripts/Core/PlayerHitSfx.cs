using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitSfx : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;

    private void OnValidate()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GenericCharacterMovementScript.OnPlayerDamaged += PlayHitClip;
    }

    private void OnDestroy()
    {
        GenericCharacterMovementScript.OnPlayerDamaged -= PlayHitClip;
    }

    private void PlayHitClip()
    {
        if (!HeartManager.Instance.PlayerIsDead)
        {
            m_audioSource.Play();
        }
    }
}
