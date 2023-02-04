using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PP_Manager : MonoBehaviour
{
    [SerializeField] private PostProcessVolume m_PP_1;
    [SerializeField] private PostProcessVolume m_PP_2;

    private void SetWeights (float weight)
    {
        m_PP_1.weight = weight;
        m_PP_2.weight = 1 - weight;
    }
}
