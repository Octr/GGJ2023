using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesDefeatedUIText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_myText;

    private void OnValidate()
    {
        m_myText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        m_myText.text = $"Waves Defeated: {WaveManager.Instance.WavesDefeated}";
    }
}
