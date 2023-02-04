using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCharacterMovementScript : MonoBehaviour
{
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
                gameObject.SetActive(false);
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
                Projectile newProjectileScript = newProjectile.GetComponent<Projectile>();
                Vector3 shootingVector = shootingDirection.forward.normalized;
                shootingVector = Quaternion.AngleAxis(Random.Range(-inaccuracy,inaccuracy), Vector3.up) * shootingVector;

                newProjectileScript.movementDirection = shootingVector;
                newProjectileScript.speed = projectileSpeed;
                newProjectileScript.damage = projectileDamage;
                newProjectileScript.isPlayerProjectile = isPlayer;
                newProjectile.transform.localScale *= projectileSize;

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
