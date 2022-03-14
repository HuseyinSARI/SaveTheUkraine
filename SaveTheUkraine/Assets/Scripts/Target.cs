using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject hitFX;
    [SerializeField] private GameObject deadFX;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private AudioClip clipToPlay;
    
    private bool isColliding = false;

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
        isColliding = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;

            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            if (bullet)
            {
                if (bullet.owner != gameObject) // for bullet not hit own owner - kurþunun kendi sahibini vurmamasý için
                {

                currentHealth -= bullet.GetBulletPower;

                AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
                    
                    if (hitFX != null && currentHealth > 0)
                    {
                        Instantiate(hitFX, transform.position, Quaternion.identity);
                    }
                    if (currentHealth <= 0)
                    {
                        Dead();
                    }

                    Destroy(other.gameObject);
                }
            }
        
    }
    private void Dead()
    {
        if(deadFX != null)
        {
            Instantiate(deadFX, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
