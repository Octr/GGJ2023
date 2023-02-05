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
    [SerializeField] private Transform rootsManagerXScale;
    private float hellxScale = 0.5f;
    private float heavenXscale = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += ResetPPWeight;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetPPWeight;
    }

    private void Update()
    {
        SetHeavenToHellPPVolumeWeight(rootsManagerXScale.localScale.x);
    }

    public void SetHeavenToHellPPVolumeWeight(float rootsXScale)
    {
        float normie;
        normie = rootsXScale / heavenXscale;
        
        if (normie > 1)
        {
            m_Heaven.weight = 0;
            m_Heaven.weight = 1;
        }
        else if (normie < 0)
        {
            m_Heaven.weight = 1;
            m_Hell.weight = 0;
        }

        m_Heaven.weight = normie;
        m_Hell.weight = 1 - normie;

    }
    
    public void ResetPPWeight(Scene arg0, LoadSceneMode loadSceneMode)
    {
        m_Heaven.weight = 1;
        m_Hell.weight = 0;
    }
}
