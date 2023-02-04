using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public bool grown;
    public float growTimer;
    public float growTime;
    public SpriteRenderer render;
    public Sprite grownSprite;

    public List<EnemyMovement> enemiesInsideArea = new List<EnemyMovement>();

    public float damageTimer;
    public float damageTime;
    public GameObject hitmarker;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grown)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer > damageTime)
            {
                damageTimer = 0;
                foreach (EnemyMovement enemy in enemiesInsideArea)
                {
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage); 
                        GameObject newHitmarker = Instantiate(hitmarker);
                        newHitmarker.transform.position = transform.position;
                    }
                }
            }
        }
        if (growTimer > growTime)
        {
            grown = true;
            render.sprite = grownSprite;
        }
        growTimer += Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesInsideArea.Add(other.gameObject.GetComponent<EnemyMovement>());
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesInsideArea.Remove(other.gameObject.GetComponent<EnemyMovement>());
        }
    }
}
