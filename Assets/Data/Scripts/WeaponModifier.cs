using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModifier : MonoBehaviour
{
	/*
	 * RateOfFire=60* A / ((A - 1) * B + C)
		Example of a single shot firing mode at a rate of fire of 20 rounds per minute. 
		- A: Primary: Salvo length (#) : 1
		- B: Primary: Salvo reload (s) : 1s
		- C: Primary: Shot reload (s): 3s
		- Rate of Fire (RPM) =  20 = 60*1 / ((1-1)x1+3) 
	 */

	
	//RoF
	[SerializeField] private int m_salvoLength =1;
	[SerializeField] private float m_salvoReload = 1;
	[SerializeField] private float m_shotReload = 1;
	[SerializeField] private float m_calculatedRateOfFire;
	
	//


	private float CalculateRateOfFire(int salvoLength, float salvoReload, float shotReload)
	{
		float rateOfFire;
		rateOfFire = 60* salvoLength / ((salvoLength - 1)* salvoReload + shotReload);
		return rateOfFire;
	}

	private void Start()
	{
		float testValue;
		Debug.Log($"Test RoF is:{CalculateRateOfFire(1,1,2)}");
	}
}
