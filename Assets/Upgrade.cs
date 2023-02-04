using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum UpgradeTypeEnum
{
    rateOfFire,
    damage,
    projectileVelocity
}

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public Upgrader upgrader;
    public TMPro.TextMeshProUGUI upgradeText;
    public Image upgradeImage;
    public UpgradeTypeEnum upgradeType;

    public void OnPointerClick(PointerEventData eventData)
    {
        upgrader.TriggerUpgrade(upgradeType);
    }

}
