using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private int maxAmmoCount = 5;
    [SerializeField] private bool isPlayer = false;
    private float currentFireRate = 0f;
    private int ammoCount = 0;

    public int GetAmmo
    {
        get
        {
            return ammoCount;
        }
        set
        {
            ammoCount = value;
            if(ammoCount > maxAmmoCount)
            {
                ammoCount = maxAmmoCount;
            }
        }
    }
    public float GetCurrentFireRate
    {
        get
        {
            return currentFireRate;
        }
        set
        {
            currentFireRate = value;
        }
    }
    public int GetClipSize
    {
        get
        {
            return maxAmmoCount;
        }
    }
    void Start()
    {
        ammoCount = maxAmmoCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime; //zamanla atýþ hýzýný azaltmak
        }

        if (isPlayer) 
        { 
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
        }
    }

    public void Fire()
    {
       float difference = 180f - transform.eulerAngles.y; //karakter hangi tarafa yakýnsa merminin rotasyonunu oraya eþitlemek.

       float targetRotation = 90f;
        if(difference >= 90f)
        {
            targetRotation = 90f;

        }else if(difference < 90f)
        {
            targetRotation = 270f;
        }
       
        currentFireRate = fireRate;  //atýþ hýzýný yeniledik.
        ammoCount -= 1; 

        GameObject bulletClone = Instantiate(ammo, firePoint.position, Quaternion.Euler(0f, 0f, targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;
    }
}
