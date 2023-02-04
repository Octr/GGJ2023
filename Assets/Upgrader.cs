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

    public float currentProjectileSizeModifier = 0.5f;
    public float maxProjectileSize;
    public float minProjectileSize;

    public float currentProjectileSpeedModifier = 0.5f;
    public float maxProjectileSpeed;
    public float minProjectileSpeed;

    public float currentTimeBetweenBurstsModifier = 0.5f;
    public float maxTimeBetweenBursts;
    public float minTimeBetweenBursts;

    public float currentDamageModifier = 0.5f;
    public float maxDamage;
    public float minDamage;

    public float currentAccuracyModifier = 0.5f;
    public float maxAccuracy;
    public float minAccuracy;

    public float currentBurstFireRate = 0.5f;
    public float maxBurstFireRate;
    public float minBurstFireRate;

    public Sprite pea;
    public Sprite carrot;
    public Sprite potato;
    public Sprite turnip;
    public Sprite pumpkin;

    public void Start()
    {
        PlayerMovementScript.instance.projectileSize = Mathf.Lerp(minProjectileSize, maxProjectileSize, currentProjectileSizeModifier);
        PlayerMovementScript.instance.projectileSpeed = Mathf.Lerp(minProjectileSpeed, maxProjectileSpeed, currentProjectileSpeedModifier);
        PlayerMovementScript.instance.timeBetweenBursts = Mathf.Lerp(minTimeBetweenBursts, maxTimeBetweenBursts, currentTimeBetweenBurstsModifier);
        PlayerMovementScript.instance.projectileDamage = Mathf.Lerp(minDamage, maxDamage, currentDamageModifier);
        PlayerMovementScript.instance.inaccuracy = Mathf.Lerp(minAccuracy, maxAccuracy, currentAccuracyModifier);
        PlayerMovementScript.instance.burstFireSpeed = Mathf.Lerp(minBurstFireRate, maxBurstFireRate, currentBurstFireRate);
        WaveEnded();
        canUpgrade = true; // start on true because no enemies 
        WaveManager.OnWaveStatusChange += OnWaveStatusUpdate;
        CheckSizeSprite();
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

    public void CheckSizeSprite()
    {
        if (currentProjectileSizeModifier < 0.5f)
        {
            PlayerMovementScript.instance.currentProjectileSprite = pea;
        }
        else if (currentProjectileSizeModifier < 0.6f)
        {
            PlayerMovementScript.instance.currentProjectileSprite = carrot;
        }
        else if (currentProjectileSizeModifier < 0.8f)
        {
            PlayerMovementScript.instance.currentProjectileSprite = potato;
        }
        else if (currentProjectileSizeModifier < 1.0f)
        {
            PlayerMovementScript.instance.currentProjectileSprite = turnip;
        }
        else
        {
            PlayerMovementScript.instance.currentProjectileSprite = pumpkin;
        }
    }

    public void TriggerUpgrade(UpgradeTypeEnum proUpgradeType, UpgradeTypeEnum conUpgradeType)
    {
        upgradeCanvas.SetActive(false);
        OnPowerUpSelected.Invoke();
        //Joe Addition

        switch (proUpgradeType)
        {
            case UpgradeTypeEnum.projectileSize:
                currentProjectileSizeModifier += 0.2f;
                PlayerMovementScript.instance.projectileSize = Mathf.Lerp(minProjectileSize, maxProjectileSize, currentProjectileSizeModifier);
                CheckSizeSprite();
                break;
            case UpgradeTypeEnum.projectileVelocity:
                currentProjectileSpeedModifier += 0.2f;
                PlayerMovementScript.instance.projectileSpeed = Mathf.Lerp(minProjectileSpeed, maxProjectileSpeed, currentProjectileSpeedModifier);
                break;
            case UpgradeTypeEnum.timeBetweenBursts:
                currentTimeBetweenBurstsModifier += 0.2f;
                PlayerMovementScript.instance.timeBetweenBursts = Mathf.Lerp(minTimeBetweenBursts, maxTimeBetweenBursts, currentTimeBetweenBurstsModifier);
                break;
            case UpgradeTypeEnum.damage:
                currentDamageModifier += 0.2f;
                PlayerMovementScript.instance.projectileDamage = Mathf.Lerp(minDamage, maxDamage, currentDamageModifier);
                break;
            case UpgradeTypeEnum.accuracy:
                currentAccuracyModifier += 0.2f;
                PlayerMovementScript.instance.inaccuracy = Mathf.Lerp(minAccuracy, maxAccuracy, currentAccuracyModifier);
                break;
            case UpgradeTypeEnum.burstFireSpeed:
                currentBurstFireRate += 0.2f;
                PlayerMovementScript.instance.burstFireSpeed = Mathf.Lerp(minBurstFireRate, maxBurstFireRate, currentBurstFireRate);
                break;
            default:
                break;
        }

        switch (conUpgradeType)
        {
            case UpgradeTypeEnum.projectileSize:
                currentProjectileSizeModifier -= 0.1f;
                PlayerMovementScript.instance.projectileSize = Mathf.Lerp(minProjectileSize, maxProjectileSize, currentProjectileSizeModifier);
                CheckSizeSprite();
                break;
            case UpgradeTypeEnum.projectileVelocity:
                currentProjectileSpeedModifier -= 0.1f;
                PlayerMovementScript.instance.projectileSpeed = Mathf.Lerp(minProjectileSpeed, maxProjectileSpeed, currentProjectileSpeedModifier);
                break;
            case UpgradeTypeEnum.timeBetweenBursts:
                currentTimeBetweenBurstsModifier -= 0.1f;
                PlayerMovementScript.instance.timeBetweenBursts = Mathf.Lerp(minTimeBetweenBursts, maxTimeBetweenBursts, currentTimeBetweenBurstsModifier);
                break;
            case UpgradeTypeEnum.damage:
                currentDamageModifier -= 0.1f;
                PlayerMovementScript.instance.projectileDamage = Mathf.Lerp(minDamage, maxDamage, currentDamageModifier);
                break;
            case UpgradeTypeEnum.accuracy:
                currentAccuracyModifier -= 0.1f;
                PlayerMovementScript.instance.inaccuracy = Mathf.Lerp(minAccuracy, maxAccuracy, currentAccuracyModifier);
                break;
            case UpgradeTypeEnum.burstFireSpeed:
                currentBurstFireRate -= 0.1f;
                PlayerMovementScript.instance.burstFireSpeed = Mathf.Lerp(minBurstFireRate, maxBurstFireRate, currentBurstFireRate);
                break;
            default:
                break;
        }


        Debug.Log("Upgrade");
    }
}
