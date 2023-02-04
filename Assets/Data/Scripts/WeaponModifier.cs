using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

//A) Player MovementScript controls 
//B) WeaponBonusScript 


public class WeaponModifier : MonoBehaviour
{
	
	//Script References
	[SerializeField] public PlayerMovementScript m_pms;
	[SerializeField] public WeaponBonus m_weaponBonus;
	//Rate of fire settings
	public int m_numPerSalvo =1; //the number of shots in the slavo
	public float m_salvoReload = 1; //Time between a new salvo
	public float m_salvoTime = 1; //time between shots within the salvo
	public float m_calculatedRateOfFire;
	//Accuracy
	public float m_dispersionAngle = 1f;
	//Other
	public float m_projectileSpeed =1; 
	
	//The Global Asset modifier
	
	

	//numPerSalvo = SalvoLength
	//salvoTime = shotReload
	//rateOfFire = salvoReload
	
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

	public void SetWeaponBonusToPlayer()
	{
		m_pms.bulletsPerBurst = (int)m_numPerSalvo;
		m_pms.burstFireSpeed = m_weaponBonus.BurstFireSpeedX;
		m_pms.timeBetweenBursts = m_weaponBonus.TimeBetweenBurstsX;
	}
	
	private void Start()
	{
		SetWeaponBonusToPlayer();
	}

	private void Update()
	{
		
		
		SetWeaponBonusToPlayer();

		
		Debug.Log($"Salvo#{m_pms.bulletsPerBurst}");
	}
}
