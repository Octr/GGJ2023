using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Upgrader : MonoBehaviour
{
    public Upgrade[] upgrades;
    public bool canUpgrade;
    public bool playerAtTree;
    public GameObject upgradeCanvas;

    public WeaponBonus m_WeaponMultiplierSource;
    
    
    
    
    
    // Start is called before the first frame update

    public void Start()
    {
        WaveEnded();
    }
    public void Update()
    {
        if (canUpgrade && playerAtTree)
        {
            canUpgrade = false;
            upgradeCanvas.SetActive(true);
        }
    }

    public void WaveEnded()
    {
        canUpgrade = true;
        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.upgradeType = (UpgradeTypeEnum)UnityEngine.Random.Range(0,Enum.GetValues(typeof(UpgradeTypeEnum)).Length);
            upgrade.upgradeText.text = upgrade.upgradeType.ToString()+" +1";
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerAtTree = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerAtTree = false;
        }
    }

    public void TriggerUpgrade(UpgradeTypeEnum upgradeType)
    {
        upgradeCanvas.SetActive(false);
        
        //Joe Addition
        switch (upgradeType)
        {
            case UpgradeTypeEnum.rateOfFire:
                PlayerMovementScript.instance.rateOfFire =  m_WeaponMultiplierSource.ChangeRateOfFireMultiplier(m_WeaponMultiplierSource.PowerUpRateOfFire); //should be set to a variable
                break;
            case UpgradeTypeEnum.damage:
                PlayerMovementScript.instance.projectileDamage=  m_WeaponMultiplierSource.ChangeDamageMultiplier(m_WeaponMultiplierSource.PowerUpDamage);
                break;
            case UpgradeTypeEnum.projectileVelocity:
                PlayerMovementScript.instance.speed = m_WeaponMultiplierSource.ChangeVelocityMultiplier(m_WeaponMultiplierSource.PowerUpVelocity);
                break;
            default:
                break;
        }
        
        
        Debug.Log("Upgrade");
    }
}
