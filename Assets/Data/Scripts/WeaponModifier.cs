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
	[SerializeField] private int m_salvoLength =1;
	[SerializeField] private float m_salvoReload = 1;
	[SerializeField] private float m_shotReload = 1;
	[SerializeField] private float m_calculatedRateOfFire;
	//Accuracy
	[SerializeField] private float m_dispersionAngle = 1f;
	//Other
	[SerializeField] private float m_projectileSpeed =1; 
	

	private float CalculateRateOfFire(int salvoLength, float salvoReload, float shotReload)
	{
		float rateOfFire;
		rateOfFire = 60* salvoLength / ((salvoLength - 1)* salvoReload + shotReload);
		return rateOfFire;
	}


	public void AdditiveWeaponMultiplier()
	{
		
	}


	public void SetWeaponBonusToPlayer()
	{
		m_playerMovementScript.numberPerSalvo = (int) (m_playerMovementScript.numberPerSalvo *m_weaponBonus.SalvoLengthX); //SalvoLength
		m_playerMovementScript.salvoTime = m_playerMovementScript.salvoTime * m_weaponBonus.SalvoReloadX;
		m_playerMovementScript.rateOfFire = m_playerMovementScript.rateOfFire * m_weaponBonus.CalculatedRateOfFireX; //RoF / Shot Length
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
