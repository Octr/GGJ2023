using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/Create WeaponDataSO", fileName = "WeaponDataSO", order = 0)]
public class WeaponDataSO : ScriptableObject
{
    public Rigidbody movementRBody;
    public float speed;

    public Transform shootingDirection;

    public GameObject projectileToShoot;

    public float fireTimer;
    public float rateOfFire;

    public float salvoTimer;
    public float salvoTime;
    public int numberPerSalvo;

    public int numberFiredSoFarInSalvo;
    public bool firingSalvo;
    public float moveX;
    public float moveY;

    public bool firing; 

}
