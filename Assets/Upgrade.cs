using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum UpgradeTypeEnum
{
    timeBetweenBursts,
    damage,
    projectileVelocity,
    accuracy,
    projectileSize,
    burstFireSpeed,
}

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public Upgrader upgrader;
    public TMPro.TextMeshProUGUI upgradeText;
    public Image upgradeImage;
    public UpgradeTypeEnum proUpgradeType;
    public UpgradeTypeEnum conUpgradeType;

    public void OnPointerClick(PointerEventData eventData)
    {
        upgrader.TriggerUpgrade(proUpgradeType,conUpgradeType);
    }

}
