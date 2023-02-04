using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimatorEffect : MonoBehaviour
{
    [SerializeField] private Animator m_treeAnimator;

    private void OnValidate()
    {
        m_treeAnimator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        m_treeAnimator.SetBool("Glow", true); // glow in beginning 
        WaveManager.OnWaveStatusChange += OnWaveStateChange;
    }

    private void OnDisable()
    {
        WaveManager.OnWaveStatusChange -= OnWaveStateChange;

    }

    private void OnWaveStateChange(bool waveIsActive)
    {
        if (waveIsActive) // yes wave no glow
        {
            m_treeAnimator.SetBool("Glow", false);
        }

        if (!waveIsActive) // no wave then glow 
        {
            m_treeAnimator.SetBool("Glow", true);
        }
    }
}
