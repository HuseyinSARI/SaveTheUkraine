using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate = 0.5f;
    private float currentFireRate = 0f;
    [SerializeField] private int ammoCount = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime; //zamanla at�� h�z�n� azaltmak
        }

        
        if(Input.GetMouseButtonDown(0))
        {
            if(currentFireRate <= 0)
            { 
                if(ammoCount > 0)
                {
                    Fire();
                }
            }
                
        }
        print(Time.deltaTime);
    }

    private void Fire()
    {
       float difference = 180f - transform.eulerAngles.y; //karakter hangi tarafa yak�nsa merminin rotasyonunu oraya e�itlemek.

       float targetRotation = 90f;
        if(difference >= 90f)
        {
            targetRotation = 90f;

        }else if(difference < 90f)
        {
            targetRotation = 270f;
        }
       
        currentFireRate = fireRate;  //at�� h�z�n� yeniledik.
        ammoCount -= 1; 

        Instantiate(ammo, firePoint.position, Quaternion.Euler(0f, 0f, targetRotation));
    }
}
