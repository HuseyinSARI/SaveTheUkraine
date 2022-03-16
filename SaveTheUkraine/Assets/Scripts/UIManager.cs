using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image healtFill;
    public Image ammoFill;
    public RawImage rpgAmmoImage;
    public RawImage pistolAmmoImage;

    private Attack playerAmmo;
    private Target playerHealt;
    private string selectedWeapon;

    private void Awake()
    {
        playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        playerHealt = playerAmmo.GetComponent<Target>();
        
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealtFill();
        UpdateAmmoFill();
        ChangeAmmoImage();
        selectedWeapon = playerAmmo.selectedWeapon;
        
    }

    private void UpdateAmmoFill()
    {
        ammoFill.fillAmount = (float)playerAmmo.GetAmmo / (float)playerAmmo.GetClipSize;
    }

    private void UpdateHealtFill()
    {
        healtFill.fillAmount = (float)playerHealt.GetHealth / (float)playerHealt.GetMaxHealth;
    }

    private void ChangeAmmoImage()
    {
        if(selectedWeapon == "Pistol")
        {
            pistolAmmoImage.enabled = true;
            rpgAmmoImage.enabled = false;
        }
        else if(selectedWeapon == "RPG")
        {
            pistolAmmoImage.enabled = false;
            rpgAmmoImage.enabled = true;
        }
    }
}
