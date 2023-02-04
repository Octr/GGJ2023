using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/Create WeaponBonus", fileName = "WeaponBonus", order = 0)]
public class WeaponBonus : ScriptableObject
{
	
	[Header("Powerup additive values")] [Tooltip("The additive value multiplier of Damage")] [Range(0.1f, 5f)]
	public float PowerUpDamage;
	[Tooltip("The additive value multiplier of Rate of Fire ")]
	public float PowerUpTimeBetweenBursts;
	[Tooltip("The additive value multiplier of Velocity")] [Range(0.1f, 5f)]
	public float PowerUpVelocity;
	[Range(0.1f, 5f)]
	public float PowerUpSize;

	[Header("Powerdown subtractive values")]
	[Tooltip("The subtractive value multiplier of Damage")]
	[Range(-0.1f, -5f)]
	public float PowerDownDamage;
	[Tooltip("The subtractive value multiplier of Rate of Fire ")]
	public float PowerDownTimeBetweenBursts;
	[Tooltip("The subtractive value multiplier of Velocity")]
	[Range(-0.1f, -5f)]
	public float PowerDownVelocity;
	[Range(-0.1f, -5f)]
	public float PowerDownSize;

	[Header("Bonus % Values (setting to 0= no bonus/nerf)")]
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	public float BulletsFiredPerBurstX =1;
	[Tooltip("Salvo Reload is the time between projectile bursts ")]
	public float TimeBetweenBurstsX = 1;
	[Tooltip("Shot Reload is the time between a projectile being fired")]
	public float BurstFireSpeedX = 1; //should be less

	//Accuracy
	[Tooltip("The angle that the projectile does not shoot accurately")]
	public float InacurracyAngleX = 1f;
	//Other
	[Tooltip("How fast the projectile can travel")]
	public float ProjectileSpeedX =1;
	[Tooltip("How big the projectile be")]
	public float ProjectileSizeX = 1;

	[Tooltip("How much damage the projectile does")]
	public float DamageX = 1;
	
	
	[Header("Maximum Values")]
	[Header("Bonus % Values (setting to 0= no bonus/nerf)")]
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	public float BulletsFiredPerBurstMin = 1;
	[Tooltip("Salvo Reload is the time between projectile bursts ")]
	public float TimeBetweenBurstsMin= 1;
	[Tooltip("Shot Reload is the time between a projectile being fired")]
	public float BurstFireSpeedMin = 1; //should be less

	//Accuracy
	[Tooltip("The angle that the projectile does not shoot accurately")]
	public float InacurracyAngleMin = 1f;
	//Other
	[Tooltip("How fast the projectile can travel")]
	public float ProjectileSpeedMin = 1;
	[Tooltip("How big the projectile be")]
	public float ProjectileSizeMin = 1;

	[Tooltip("How much damage the projectile does")]
	public float DamageMin = 1;


	[Header("Minimum Values")]
	[Header("Bonus % Values (setting to 0= no bonus/nerf)")]
	[Tooltip("Salvo Length, is the number of projecticles fired in series ")]
	public float BulletsFiredPerBurstMax = 1;
	[Tooltip("Salvo Reload is the time between projectile bursts ")]
	public float TimeBetweenBurstsMax = 1;
	[Tooltip("Shot Reload is the time between a projectile being fired")]
	public float BurstFireSpeedMax = 1; //should be less

	//Accuracy
	[Tooltip("The angle that the projectile does not shoot accurately")]
	public float InacurracyAngleMax = 1f;
	//Other
	[Tooltip("How fast the projectile can travel")]
	public float ProjectileSpeedMax = 1;
	[Tooltip("How big the projectile be")]
	public float ProjectileSizeMax = 1;

	[Tooltip("How much damage the projectile does")]
	public float DamageMax = 1;



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

	public float ChangeTimeBetweenBurstsMultiplier(float changeMultiplier) //0
	{
		float result;
		result= SetAndCheckMultiplier(BurstFireSpeedX, changeMultiplier, TimeBetweenBurstsMin, TimeBetweenBurstsMax);
		Debug.Log($"ChangeRateOfFireMultiplier Result: {result}");
		return result;
	}
	
	public float ChangeDamageMultiplier(float changeMultiplier) //1
	{
		float result;
		result= SetAndCheckMultiplier( DamageX, changeMultiplier, DamageMin, DamageMax);
		Debug.Log($"ChangeDamageMultiplier Result: {result}");
		return result;
	}
	
	public float ChangeVelocityMultiplier(float changeMultiplier) //2
	{
		float result;
		result= SetAndCheckMultiplier( ProjectileSpeedX, changeMultiplier, ProjectileSpeedMin, ProjectileSpeedMax);
		Debug.Log($"ChangeVelocityMultiplier Result: {result}");
		return result;
	}
	public float ChangeSizeMultiplier(float changeMultiplier) //2
	{
		float result;
		result = SetAndCheckMultiplier(ProjectileSizeX, changeMultiplier, ProjectileSizeMin, ProjectileSizeMax);
		Debug.Log($"ChangeSizeMultiplier Result: {result}");
		return result;
	}
}
