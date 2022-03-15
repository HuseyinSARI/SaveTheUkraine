using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image healtFill;
    public Image ammoFill;

    private Attack playerAmmo;
    private Target playerHealt;

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
    }

    private void UpdateAmmoFill()
    {
        ammoFill.fillAmount = (float)playerAmmo.GetAmmo / (float)playerAmmo.GetClipSize;
    }

    private void UpdateHealtFill()
    {
        healtFill.fillAmount = (float)playerHealt.GetHealth / (float)playerHealt.GetMaxHealth;
    }
}
