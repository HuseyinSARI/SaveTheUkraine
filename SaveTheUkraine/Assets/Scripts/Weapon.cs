using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Attack attack;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float fireRate;
    [SerializeField] private int clipSize;
    private int currentAmmoCount;

    public int GetCurrentWeaponAmmoCount
    {
        get
        {
            return currentAmmoCount;
        }
        set
        {
            currentAmmoCount = value;
        }
    }
    //Deðer ve referans atamalarý oyun baþlamadan önce çaðýrýlmalý ve koþulmalý.
    //"Awake" fonksiyonu diðer fonksiyonlardan önce ilk olarak oyunda çalýþýr. 
    // Deðer atamalarýný bu metotda yapýlmalýdýr.
    private void Awake()
    {
        currentAmmoCount = clipSize;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnEnable()
    {
        if (attack!=null)
        {            
            //attack scriptnin içindeki deðerleri weapon scripti içinden doldurduk.
            attack.GetFireTransform = fireTransform;
            attack.GetFireRate = fireRate;
            attack.GetClipSize = clipSize;
            attack.GetAmmo = currentAmmoCount;

        }
    }
}
