using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponStatsUIDebug : MonoBehaviour
{
    public PlayerMovementScript m_Pms;
    public TextMeshProUGUI m_salvoLength;
    public TextMeshProUGUI m_salvoReload;
    public TextMeshProUGUI m_shotReload;
    //public TextMeshProUGUI m_projectileVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        m_salvoLength.text = $"{m_Pms.numberPerSalvo}";
        m_salvoReload.text = $"{m_Pms.rateOfFire}";
        m_shotReload.text = $"{m_Pms.salvoTime}";


    }
}
