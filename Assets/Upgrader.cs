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
        Debug.Log("Upgrade");
    }
}
