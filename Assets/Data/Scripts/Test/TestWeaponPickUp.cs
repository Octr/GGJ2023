using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestWeaponPickUp : MonoBehaviour
{
    // Start is called before the first frame update

    public WeaponBonus m_wBonus;
    public WeaponModifier m_wModifer;
    public PlayerMovementScript m_PlayerMovementScript;
    
    //Rate of fire settings
    public float m_salvoLength =1;
    public float m_salvoReload = 1;
    public float m_shotReload = 1;
    public float m_calculatedRateOfFire;
    //Accuracy
    public float m_dispersionAngle = 1f;
    //Other
    public float m_projectileSpeed =1; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetShotMultiplier();
            SetSalveLengthMultipler();
            Destroy(this.gameObject);
        }
    }
    
    private void SetShotMultiplier()
    {
        //Rate of fire multiplier test
        m_shotReload = m_wModifer.CalculateMultiplier(
            m_wModifer.m_salvoTime, 
            m_wBonus.BurstFireSpeedX, 
            m_wBonus.BurstFireSpeedMin, 
            m_wBonus.BurstFireSpeedMax);

        m_PlayerMovementScript.timeBetweenBursts = m_shotReload;
    }
    
    
    private void SetSalveLengthMultipler()
    {
        //Rate of fire multiplier test
        m_salvoLength = m_wModifer.CalculateMultiplier(
            m_wModifer.m_numPerSalvo, 
            m_wBonus.BulletsFiredPerBurstX, 
            m_wBonus.BulletsFiredPerBurstMin, 
            m_wBonus.BulletsFiredPerBurstMax);

        m_PlayerMovementScript.timeBetweenBursts = m_salvoLength;
    }
}
