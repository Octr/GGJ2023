using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GenericCharacterMovementScript : MonoBehaviour
{

    public AudioClip enemyShootSound;
    public static event Action OnPlayerDamaged = () => { };
    
    public Sprite currentProjectileSprite;

    public Rigidbody movementRBody;
    public float speed;

    public Transform shootingDirection;

    public GameObject projectileToShoot;

    public float fireTimer;
    public float timeBetweenBursts;

    public float salvoTimer;
    public float burstFireSpeed;
    public int bulletsPerBurst;

    public int numberFiredSoFarInSalvo;
    public bool firingSalvo;
    public float moveX;
    public float moveY;

    public float projectileSpeed;
    public float projectileDamage;
    public float projectileSize;

    public float inaccuracy;

    public bool firing;

    public float health = 100;

    public bool isPlayer;

    public Transform shootingPos;

    public float yMovementPerspectiveMultiplier;

    public Animator animator1;
    public Animator animator2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        Move();
        FiringInput();
    }

    public virtual void FiringInput()
    {

    }

    public void TakeDamage(float newDamage)
    {
        
        if (isPlayer)
        {
            OnPlayerDamaged.Invoke();
            CameraShake.instance.CameraShakeByTime(0.1f, 0.3f);
        }
        else
        {
            CameraShake.instance.CameraShakeByTime(0.05f, 0.1f);
        }
        
        health -= newDamage;
        if (health <= 0)
        {
            Death();
            if (!isPlayer)
            {
                Destroy(gameObject);
            }
            else
            {
                enabled = false;
            }
        }
        
    }
    public virtual void Move()
    {
        Vector3 newMovementVelocity = new Vector3(moveX, 0, moveY);
        if (newMovementVelocity.magnitude > 1.0f)
        {
            newMovementVelocity.Normalize();
        }
        newMovementVelocity.z *= yMovementPerspectiveMultiplier;
        movementRBody.velocity = newMovementVelocity * speed * Time.deltaTime;
        if (movementRBody.velocity.magnitude > 0)
        {
            if (animator1 != null)
            {

                animator1.SetFloat("Movement", Mathf.Min(movementRBody.velocity.magnitude, 0.5f));
                animator1.SetFloat("MoveX", moveX);
                animator1.SetFloat("MoveY", moveY);
            }
            if (animator2 != null)
            {
                animator2.SetFloat("Movement", Mathf.Min(movementRBody.velocity.magnitude, 0.5f));
                animator2.SetFloat("MoveX", moveX);
                animator2.SetFloat("MoveY", moveY);
            }
        }
    }

    public virtual void Look()
    {

    }
    public virtual void Death()
    {
        
    }
    public void Update()
    {
        Look();
        if (!firingSalvo)
        {
            fireTimer -= Time.deltaTime;
        }
        else
        {
            salvoTimer -= Time.deltaTime;
        }
        
        if (firing)
        {
            //Try to shoot
            if (fireTimer < 0 && !firingSalvo)
            {
                firingSalvo = true;
                numberFiredSoFarInSalvo = 0;
                salvoTimer = burstFireSpeed;
                fireTimer = timeBetweenBursts;
            }
            if (salvoTimer < 0)
            {
                GameObject newProjectile = Instantiate(projectileToShoot);
                newProjectile.transform.position = shootingPos.position;
                Projectile newProjectileScript = newProjectile.transform.GetChild(0).GetComponent<Projectile>();
                Vector3 shootingVector = shootingDirection.forward.normalized;
                shootingVector = Quaternion.AngleAxis(UnityEngine.Random.Range(-inaccuracy,inaccuracy), Vector3.up) * shootingVector;

                newProjectileScript.movementDirection = shootingVector;
                newProjectileScript.speed = projectileSpeed;
                newProjectileScript.damage = projectileDamage;
                newProjectileScript.isPlayerProjectile = isPlayer;
                newProjectile.transform.localScale *= projectileSize;
                if (!isPlayer)
                {
                    
                    newProjectile.GetComponent<AudioSource>().clip = enemyShootSound;
                    newProjectile.GetComponent<AudioSource>().volume = 0.5f;
                    newProjectile.GetComponent<AudioSource>().Play();
                }
                else
                {
                    CameraShake.instance.CameraShakeByTime(0.05f, 0.05f);
                }
                if (currentProjectileSprite != null)
                {
                    newProjectileScript.render.sprite = currentProjectileSprite;
                }

                salvoTimer = burstFireSpeed;
                numberFiredSoFarInSalvo += 1;
                if (numberFiredSoFarInSalvo >= bulletsPerBurst)
                {
                    firingSalvo = false;
                }
            }
        }
    }
}
