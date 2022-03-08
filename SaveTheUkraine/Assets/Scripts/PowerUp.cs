using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healthPowerUp = false;
    public int healAmount = 1;

    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 3;

    [Header("Transform Settings")]
    [SerializeField] private float turnSpeed = 150f;

    void Start()
    {
        if(healthPowerUp && ammoPowerUp)
        {
            healthPowerUp = false;
            ammoPowerUp = false;

        }else if (healthPowerUp)
        {
            ammoPowerUp = false;

        }else if (ammoPowerUp)
        {
            healthPowerUp = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnSpeed * Time.deltaTime , turnSpeed*Time.deltaTime, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (healthPowerUp)
            {
                other.gameObject.GetComponent<Target>().GetHealth += healAmount;
            }else if (ammoPowerUp)
            {
                other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
            }
            Destroy(gameObject);
            print(gameObject.name);
        }        
    }

}
