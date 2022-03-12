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
    //De�er ve referans atamalar� oyun ba�lamadan �nce �a��r�lmal� ve ko�ulmal�.
    //"Awake" fonksiyonu di�er fonksiyonlardan �nce ilk olarak oyunda �al���r. 
    // De�er atamalar�n� bu metotda yap�lmal�d�r.
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
            //attack scriptnin i�indeki de�erleri weapon scripti i�inden doldurduk.
            attack.GetFireTransform = fireTransform;
            attack.GetFireRate = fireRate;
            attack.GetClipSize = clipSize;
            attack.GetAmmo = currentAmmoCount;

        }
    }
}
