using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float totalTime;
    public float maxTime;
    public Vector3 movementDirection;
    public float speed;
    public float damage;

    public GameObject hitmarker;

    public bool isPlayerProjectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= maxTime)
        {
            Destroy(gameObject);
        }
        transform.Translate(movementDirection*speed*Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" && !isPlayerProjectile) ||
            (other.tag == "Enemy" && isPlayerProjectile))
        {
            other.GetComponent<GenericCharacterMovementScript>().TakeDamage(damage);
            GameObject newHitmarker = Instantiate(hitmarker);
            newHitmarker.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
