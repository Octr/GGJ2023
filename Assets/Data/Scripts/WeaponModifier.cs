using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponModifier : MonoBehaviour
{
	
	//Script References
	[SerializeField] public PlayerMovementScript m_playerMovementScript;
	[SerializeField] public WeaponBonus m_weaponBonus;
	//Rate of fire settings
	public int m_salvoLength =1;
	public float m_salvoReload = 1;
	public float m_shotReload = 1;
	public float m_calculatedRateOfFire;
	//Accuracy
	public float m_dispersionAngle = 1f;
	//Other
	public float m_projectileSpeed =1; 
	

	public float CalculateRateOfFire(int salvoLength, float salvoReload, float shotReload)
	{
		float rateOfFire;
		rateOfFire = 60* salvoLength / ((salvoLength - 1)* salvoReload + shotReload);
		return rateOfFire;
	}


	public float CalculateMultiplier(float currentMultiplierValue, float pickupBonusValue, float minValue, float maxValue)
	{
		float result;

		result = currentMultiplierValue + (1 + (pickupBonusValue / 100)); //Calculation

		if (result > maxValue)
		{
			result = maxValue;
		}
		else if (result< minValue)
		{
			result = minValue;
		}
		
		return result;
	}

	public void AdditiveWeaponMultiplier()
	{
		
	}


	public void SetWeaponBonusToPlayer()
	{
		m_playerMovementScript.numberPerSalvo = (int) (m_playerMovementScript.numberPerSalvo *m_weaponBonus.SalvoLengthX); //SalvoLength
		m_playerMovementScript.salvoTime = m_playerMovementScript.salvoTime * m_weaponBonus.SalvoReloadX;
		m_playerMovementScript.rateOfFire = m_playerMovementScript.rateOfFire * m_weaponBonus.ShotReloadX; //RoF / Shot Length
	}
	
	private void Start()
	{
		SetWeaponBonusToPlayer();
	}

	private void Update()
	{
		SetWeaponBonusToPlayer();
	}
}
