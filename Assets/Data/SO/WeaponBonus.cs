using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/Create WeaponBonus", fileName = "WeaponBonus", order = 0)]
public class WeaponBonus : ScriptableObject
{
	
	[Header("Powerup additive values")] [Tooltip("The additive value multiplier of Damage")] [Range(0.1f, 5f)]
	public float PowerUpDamage;
	[Tooltip("The additive value multiplier of Rate of Fire ")]
	public float PowerUpRateOfFire;
	[Tooltip("The additive value multiplier of Velocity")] [Range(0.1f, 5f)]
	public float PowerUpVelocity;
	
	[Header("Bonus % Values (setting to 0= no bonus/nerf)")]
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	public float SalvoLengthX =1;
	[Tooltip("Salvo Reload is the time between projectile bursts ")]
	public float SalvoReloadX = 1;
	[Tooltip("Shot Reload is the time between a projectile being fired")]
	public float ShotReloadX = 1; //should be less
	[Tooltip("Not currently used")]
	public float CalculatedRateOfFireX= 1;
	//Accuracy
	[Tooltip("The angle that the projectile does not shoot accurately")]
	public float DispersionAngleX = 1f;
	//Other
	[Tooltip("How fast the projectile can travel")]
	public float ProjectileSpeedX =1;

	[Tooltip("How much damage the projectile does")]
	public float Damage = 1;
	
	
	[Header("Maximum Values")]
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	[Range(1f,10f)]public float SalvoLengthMAX =1;
	[Tooltip("Salvo Reload is the time between projectile bursts ")]
	[Range(1f,10f)]public float SalvoReloadMAX = 1;
	[Tooltip("Shot Reload is the time between a projectile being fired")]
	public float ShotReloadMAX = 10f; // Note that should be decreasing
	[Range(1f,10f)]public float CalculatedRateOfFireMAX= 1;
	//Accuracy
	[Tooltip("The angle that the projectile does not shoot accurately")]
	[Range(1f,10f)]public float DispersionAngleMAX = 1f;
	//Other
	[Tooltip("How fast the projectile can travel")]
	[Range(1f,10f)]public float ProjectileSpeedMAX =1; 
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	[Range(1f,10f)]public float DamageMAX =10;
	
	
	[Header("Minimum Values")]
	[Range(0.1f,10f)]public float SalvoLengthMIN =1;
	[Range(0.1f,10f)]public float SalvoReloadMUN = 1;
	public float ShotReloadMIN = -10f;
	[Range(0.1f,10f)]public float CalculatedRateOfFireMIN= 1;
	//Accuracy
	[Range(1f,10f)]public float DispersionAngleMIN = 1f;
	//Other
	[Range(0.1f,10f)]public float ProjectileSpeedMIN =1;
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	[Range(0.1f,10f)]public float DamageMIN =0.1f;



	public float SetAndCheckMultiplier(float sourceValue, float changeValue, float min, float max)
	{
		float result;
		result = sourceValue + changeValue;

		if (result > max)
		{
			result = max;
		}
		else if(result < min)
		{
			result = min;
		}
		return result;
	}
	
	
	
	//0 rateOfFire,
	//1 damage,
	//2 projectileVelocity

	public float ChangeRateOfFireMultiplier(float changeMultiplier) //0
	{
		float result;
		result= SetAndCheckMultiplier(ShotReloadX, changeMultiplier, ShotReloadMIN, ShotReloadMAX);
		Debug.Log($"ChangeRateOfFireMultiplier Result: {result}");
		return result;
	}
	
	public float ChangeDamageMultiplier(float changeMultiplier) //1
	{
		float result;
		result= SetAndCheckMultiplier( Damage, changeMultiplier, DamageMIN, DamageMAX);
		Debug.Log($"ChangeDamageMultiplier Result: {result}");
		return result;
	}
	
	public float ChangeVelocityMultiplier(float changeMultiplier) //2
	{
		float result;
		result= SetAndCheckMultiplier( ProjectileSpeedX, changeMultiplier, ProjectileSpeedMIN, ProjectileSpeedMAX);
		Debug.Log($"ChangeVelocityMultiplier Result: {result}");
		return result;
	}

}
