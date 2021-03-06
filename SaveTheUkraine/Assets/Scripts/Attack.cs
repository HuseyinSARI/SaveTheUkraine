using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject[] ammo;
    [SerializeField] private bool isPlayer = false;

    private GameManager gameManager;
    private int maxAmmoCount = 5;
    private int ammoCount = 0;
    private Transform fireTransform;
    private AudioClip clipToPlay;
    private AudioSource audioSource;
    private float fireRate = 0.5f;
    private float currentFireRate = 0f;

    public string selectedWeapon = "Pistol";
    
    
    public AudioClip GetClipToPlay
    {
        get
        {
            return clipToPlay;
        }
        set
        {
            clipToPlay = value;
        }
    }
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
   
    
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime; //zamanla at?? h?z?n? azaltmak
        }

        PlayerInput();
        
    }

    private void PlayerInput()
    {
        if (isPlayer && !gameManager.GetLevelFinished)
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
                    
                    weapons[1].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount; //silah de?i?tirdi?inde kapatt???m?z silah?n mermi say?s?n? silaha geri yolluyoruz.
                  
                    weapons[0].SetActive(true);
                    weapons[1].SetActive(false);
                    selectedWeapon = "Pistol";
                    break;
                case "2":
                    weapons[0].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount; //silah de?i?tirdi?inde kapatt???m?z silah?n mermi say?s?n? silaha geri yolluyoruz.
                  
                    weapons[0].SetActive(false);
                    weapons[1].SetActive(true);
                    selectedWeapon = "RPG";
                    break;
                default:
                    break;
            }
        }
    }

    public void Fire()
    {
       float difference = 180f - transform.eulerAngles.y; //karakter hangi tarafa yak?nsa merminin rotasyonunu oraya e?itlemek.

       float targetRotation = 90f;
        if(difference >= 90f)
        {
            targetRotation = 90f;

        }else if(difference < 90f)
        {
            targetRotation = 270f;
        }
       
        currentFireRate = fireRate;  //at?? h?z?n? yeniledik.
        ammoCount -= 1;
        audioSource.PlayOneShot(clipToPlay);

        if (isPlayer)
        {
            if (weapons[0].activeSelf)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(ammo[0], fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
                bulletClone.GetComponent<Bullet>().owner = gameObject;  //mermiyi olu?turdu?umuz esnada sahibini tan?mlamak
            }
            else if (weapons[1].activeSelf)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(ammo[1], fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
                bulletClone.GetComponent<Bullet>().owner = gameObject;  //mermiyi olu?turdu?umuz esnada sahibini tan?mlamak
            }
        }
        else
        {
            GameObject bulletClone;
            bulletClone = Instantiate(ammo[0], fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
            bulletClone.GetComponent<Bullet>().owner = gameObject;  //mermiyi olu?turdu?umuz esnada sahibini tan?mlamak
        }     
        
    }
}
