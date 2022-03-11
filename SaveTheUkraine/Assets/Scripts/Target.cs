using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    private int currentHealth;
    public int GetHealth  //C# Priority
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    private void Awake()
    {
       currentHealth = maxHealth;     
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if (bullet)
        {
            if(bullet.owner != gameObject) // for bullet not hit own owner - kurþunun kendi sahibini vurmamasý için
            {
                currentHealth--;
                if(currentHealth <= 0) 
                {
                    Dead();
                }

                Destroy(other.gameObject);
            }
        }
    }
    private void Dead()
    {
        Destroy(gameObject);
    }
}
