using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WeaponStatsUI : MonoBehaviour
{
    public PlayerMovementScript m_Pms;
    public TextMeshProUGUI m_RoF;
    //public TextMeshProUGUI m_projectileVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private float CalculateRateOfFire(int salvoLength, float salvoReload, float shotReload)
    {
        float rateOfFire;
        rateOfFire = 60* salvoLength / ((salvoLength - 1)* salvoReload + shotReload);
        return rateOfFire;
    }
    void Update()
    {
        //RoF
        float rof = CalculateRateOfFire(((int)m_Pms.bulletsPerBurst), m_Pms.timeBetweenBursts,m_Pms.burstFireSpeed );
        m_RoF.text = $"{rof:N0}";
        //
        //m_projectileVelocity.text = $"{m_Pms.speed}";


    }

    private void OnValidate()
    {
        
    }
}
