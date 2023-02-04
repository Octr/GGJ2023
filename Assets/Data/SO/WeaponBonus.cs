using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GamJam/Create WeaponBonus", fileName = "WeaponBonus", order = 0)]
public class WeaponBonus : ScriptableObject
{
	public float SalvoLengthX =1;
	public float SalvoReloadX = 1;
	public float ShotReloadX = 1;
	public float CalculatedRateOfFireX= 1;
	//Accuracy
	public float DispersionAngleX = 1f;
	//Other
	public float ProjectileSpeedX =1; 
}
