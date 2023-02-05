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
    seed,
}

public class Upgrade : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Upgrader upgrader;
    public TMPro.TextMeshProUGUI upgradeText;
    public Image upgradeImage;
    public UpgradeTypeEnum proUpgradeType;
    public UpgradeTypeEnum conUpgradeType;

    public bool hovered;
    public float maxScale;
    public float minScale;
    public float scalerNormalisedTimer;

    public void OnPointerClick(PointerEventData eventData)
    {
        upgrader.TriggerUpgrade(proUpgradeType,conUpgradeType);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }
    public void Update()
    {
        if (hovered)
        {
            if (scalerNormalisedTimer < 1)
            {
                scalerNormalisedTimer += Time.deltaTime*4;
            }
        }
        else
        {
            if (scalerNormalisedTimer > 0)
            {
                scalerNormalisedTimer -= Time.deltaTime*4;
            }
        }
        float scale = Mathf.Lerp(minScale,maxScale,scalerNormalisedTimer);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
