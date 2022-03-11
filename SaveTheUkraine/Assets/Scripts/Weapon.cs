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
    void Start()
    {
        currentAmmoCount = clipSize;
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
            attack.GetAmmo = clipSize;
        }
    }
}
