using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 newMovementVelocity = new Vector3(moveX,0,moveY);
        if (newMovementVelocity.magnitude > 1.0f)
        {
            newMovementVelocity.Normalize();
        }
        movementRBody.velocity = newMovementVelocity*speed*Time.deltaTime;

        
    }
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            shootingDirection.LookAt(hit.point); // Look at the point
            shootingDirection.rotation = Quaternion.Euler(new Vector3(0, shootingDirection.rotation.eulerAngles.y, 0)); // Clamp the x and z rotation
        }
        if (!firingSalvo)
        {
            fireTimer -= Time.deltaTime;
        }
        else
        {
            salvoTimer -= Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.Mouse0))
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
