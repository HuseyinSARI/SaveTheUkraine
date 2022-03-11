using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject ammo;
    [SerializeField] private bool isPlayer = false;

    private int maxAmmoCount = 5;
    private int ammoCount = 0;
    private Transform fireTransform;
    private float fireRate = 0.5f;
    private float currentFireRate = 0f;
    

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
        set
        {
            maxAmmoCount = value;
        }
    }
    public float GetFireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }
    public Transform GetFireTransform
    {
        get
        {
            return fireTransform;
        }
        set
        {
            fireTransform = value;
        }
    }
    void Start()
    {
        //ammoCount = maxAmmoCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime; //zamanla atýþ hýzýný azaltmak
        }

        PlayerInput();
    }

    private void PlayerInput()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFireRate <= 0)
                {
                    if (ammoCount > 0)
                    {
                        Fire();
                    }
                }

            }
            switch (Input.inputString)
            {
                case "1":
                    
                    weapons[1].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount; //silah deðiþtirdiðinde kapattýðýmýz silahýn mermi sayýsýný silaha geri yolluyoruz.
                  
                    weapons[0].SetActive(true);
                    weapons[1].SetActive(false);
                    break;
                case "2":
                    weapons[0].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount; //silah deðiþtirdiðinde kapattýðýmýz silahýn mermi sayýsýný silaha geri yolluyoruz.
                  
                    weapons[0].SetActive(false);
                    weapons[1].SetActive(true);
                    break;
                default:
                    break;
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

        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;  //mermiyi oluþturduðumuz esnada sahibini tanýmlamak
    }
}
