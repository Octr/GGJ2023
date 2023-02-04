using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Upgrader : MonoBehaviour
{
    public static event Action OnPowerUpSelected = () => {}; // WaveManager subbed 
    
    public Upgrade[] upgrades;
    public bool canUpgrade;
    public bool playerAtTree;
    public GameObject upgradeCanvas;

    public WeaponBonus m_WeaponMultiplierSource;
    
    public void Start()
    {
        WaveEnded();
        canUpgrade = true; // start on true because no enemies 
        WaveManager.OnWaveStatusChange += OnWaveStatusUpdate;
    }
    
    private void OnDisable()
    {
        WaveManager.OnWaveStatusChange -= OnWaveStatusUpdate;
    }

    private void OnWaveStatusUpdate(bool waveIsActive)
    {
        if (!waveIsActive)
        {
            canUpgrade = true;
            WaveEnded();
        }
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
            upgrade.proUpgradeType = (UpgradeTypeEnum)UnityEngine.Random.Range(0,Enum.GetValues(typeof(UpgradeTypeEnum)).Length);
            upgrade.conUpgradeType = (UpgradeTypeEnum)UnityEngine.Random.Range(0, Enum.GetValues(typeof(UpgradeTypeEnum)).Length);
            upgrade.upgradeText.text = upgrade.proUpgradeType.ToString()+" +2\n"+ upgrade.conUpgradeType.ToString()+" -1";
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

    public void TriggerUpgrade(UpgradeTypeEnum proUpgradeType, UpgradeTypeEnum conUpgradeType)
    {
        upgradeCanvas.SetActive(false);
        OnPowerUpSelected.Invoke();
        //Joe Addition

        switch (proUpgradeType)
        {
            case UpgradeTypeEnum.timeBetweenBursts:
                PlayerMovementScript.instance.timeBetweenBursts = m_WeaponMultiplierSource.ChangeTimeBetweenBurstsMultiplier(m_WeaponMultiplierSource.PowerUpTimeBetweenBursts); //should be set to a variable
                break;
            case UpgradeTypeEnum.damage:
                PlayerMovementScript.instance.projectileDamage = m_WeaponMultiplierSource.ChangeDamageMultiplier(m_WeaponMultiplierSource.PowerUpDamage);
                break;
            case UpgradeTypeEnum.projectileVelocity:
                PlayerMovementScript.instance.projectileSpeed = m_WeaponMultiplierSource.ChangeVelocityMultiplier(m_WeaponMultiplierSource.PowerUpVelocity);
                break;
            case UpgradeTypeEnum.projectileSize:
                PlayerMovementScript.instance.projectileSize = m_WeaponMultiplierSource.ChangeSizeMultiplier(m_WeaponMultiplierSource.PowerUpSize);
                break;
            default:
                break;
        }

        switch (conUpgradeType)
        {
            case UpgradeTypeEnum.timeBetweenBursts:
                PlayerMovementScript.instance.timeBetweenBursts = m_WeaponMultiplierSource.ChangeTimeBetweenBurstsMultiplier(m_WeaponMultiplierSource.PowerDownTimeBetweenBursts); //should be set to a variable
                break;
            case UpgradeTypeEnum.damage:
                PlayerMovementScript.instance.projectileDamage = m_WeaponMultiplierSource.ChangeDamageMultiplier(m_WeaponMultiplierSource.PowerDownDamage);
                break;
            case UpgradeTypeEnum.projectileVelocity:
                PlayerMovementScript.instance.projectileSpeed = m_WeaponMultiplierSource.ChangeVelocityMultiplier(m_WeaponMultiplierSource.PowerDownVelocity);
                break;
            case UpgradeTypeEnum.projectileSize:
                PlayerMovementScript.instance.projectileSize = m_WeaponMultiplierSource.ChangeSizeMultiplier(m_WeaponMultiplierSource.PowerDownSize);
                break;
            default:
                break;
        }


        Debug.Log("Upgrade");
    }
}
