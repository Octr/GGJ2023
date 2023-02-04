using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class PostProcessingVolumeManager : SingletonParent<PostProcessingVolumeManager>
{
    [SerializeField] private  PostProcessVolume m_Heaven;
    [SerializeField] private  PostProcessVolume m_Hell;
    [Tooltip("This is a normalized value (0-1)"), Range(0, 1)] public float HeavenToHellSlider;

    private float testMax = 10;
    private float testMin = 7;
    private float normie;
    
    public void SetHeavenToHellPPVolumeWeight(float value)
    {
        if (value > 1)
        {
            m_Heaven.weight = 1;
        }
        else if (value < 0)
        {
            m_Heaven.weight = 0;
        }

        m_Heaven.weight = value;
        m_Hell.weight = 1 - value;

    }

    public void NSetPPWeight(float realValue, float maxValue)
    {
        normie = realValue / maxValue;
        Debug.Log($"Max:{testMax}, Min:{testMin}, the normie is: {normie}");
        
    }


    public void RestPPWeight(Scene arg0, LoadSceneMode loadSceneMode)
    {
        m_Heaven.weight = 1;
        m_Hell.weight = 0;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        NSetPPWeight(12, 20);
        SceneManager.sceneLoaded += RestPPWeight;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= RestPPWeight;
    }
}
