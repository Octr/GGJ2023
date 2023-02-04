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
    public float rateOfFire;

    public float salvoTimer;
    public float salvoTime;
    public int numberPerSalvo;

    public int numberFiredSoFarInSalvo;
    public bool firingSalvo;
    public float moveX;
    public float moveY;

    public bool firing; 

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

    public virtual void Move()
    {
        Vector3 newMovementVelocity = new Vector3(moveX, 0, moveY);
        if (newMovementVelocity.magnitude > 1.0f)
        {
            newMovementVelocity.Normalize();
        }
        movementRBody.velocity = newMovementVelocity * speed * Time.deltaTime;
    }

    public virtual void Look()
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
                salvoTimer = salvoTime;
                fireTimer = rateOfFire;
            }
            if (salvoTimer < 0)
            {
                GameObject newProjectile = Instantiate(projectileToShoot);
                newProjectile.transform.position = transform.position;
                newProjectile.GetComponent<Projectile>().movementDirection = shootingDirection.forward.normalized;
                salvoTimer = salvoTime;
                numberFiredSoFarInSalvo += 1;
                if (numberFiredSoFarInSalvo >= numberPerSalvo)
                {
                    firingSalvo = false;
                }
            }
        }
    }
}
