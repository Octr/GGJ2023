using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/Create WeaponBonus", fileName = "WeaponBonus", order = 0)]
public class WeaponBonus : ScriptableObject
{
	[Header("Bonus % Values (setting to 0= no bonus/nerf)")]
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	public float SalvoLengthX =1;
	[Tooltip("Salvo Reload is the time between projectile bursts ")]
	public float SalvoReloadX = 1;
	[Tooltip("Shot Reload is the time between a projectile being fired")]
	public float ShotReloadX = 1;
	[Tooltip("Not currently used")]
	public float CalculatedRateOfFireX= 1;
	//Accuracy
	[Tooltip("The angle that the projectile does not shoot accurately")]
	public float DispersionAngleX = 1f;
	//Other
	[Tooltip("How fast the projectile can travel")]
	public float ProjectileSpeedX =1; 
	
	[Header("Maximum Values")]
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	[Range(1f,10f)]public float SalvoLengthMAX =1;
	[Tooltip("Salvo Reload is the time between projectile bursts ")]
	[Range(1f,10f)]public float SalvoReloadMAX = 1;
	[Tooltip("Shot Reload is the time between a projectile being fired")]
	[Range(1f,10f)]public float ShotReloadMAX = 1;
	[Range(1f,10f)]public float CalculatedRateOfFireMAX= 1;
	//Accuracy
	[Tooltip("The angle that the projectile does not shoot accurately")]
	[Range(1f,10f)]public float DispersionAngleMAX = 1f;
	//Other
	[Tooltip("How fast the projectile can travel")]
	[Range(1f,10f)]public float ProjectileSpeedMAX =1; 
	
	[Header("Minimum Values")]
	[Range(0.1f,10f)]public float SalvoLengthMIN =1;
	[Range(0.1f,10f)]public float SalvoReloadMUN = 1;
	[Range(0.1f,10f)]public float ShotReloadMIN = 1;
	[Range(0.1f,10f)]public float CalculatedRateOfFireMIN= 1;
	//Accuracy
	[Range(1f,10f)]public float DispersionAngleMIN = 1f;
	//Other
	[Range(0.1f,10f)]public float ProjectileSpeedMIN =1; 
	
	
	
}
