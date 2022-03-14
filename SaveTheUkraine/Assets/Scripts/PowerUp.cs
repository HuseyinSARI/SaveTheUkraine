using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;

    [Header("Health Settings")]
    public bool healthPowerUp = false;
    public int healAmount = 1;

    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 3;

    [Header("Transform Settings")]
    [SerializeField] private Vector3 turnVector = Vector3.zero;

    [Header("Scale Settings")]
    [SerializeField] private float period = 2f;
    [SerializeField] private Vector3 scaleVector;
    


    private float scaleFactor;
    private Vector3 startScale;

    private void Awake()
    {
        startScale = transform.localScale;
        
    }
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
        transform.Rotate(turnVector);
        SinusWave();
    }

    private void SinusWave()
    {
        if ( period <= 0f)
        {
            period = 0.1f;
        }
        float cycles = Time.timeSinceLevelLoad / period;   //sin dalgas�n�n periyodunu d��ar�dan kontrol edebilmek i�in
                                                                     
        const float piX2 = Mathf.PI *2 ;    // 2 pi

        float sinusWave = Mathf.Sin(cycles * piX2); // sin dalgas�n�n y eksisndeki float de�erini olu�turduk -1, 1
                                                                  
        scaleFactor = sinusWave / 2 + 0.5f;  //  0, 1
        
        Vector3 offset = scaleVector * scaleFactor;   // scale de�erine inspector dan de�i�tirmek i�in
                                                    
        transform.localScale = startScale + offset;  // uygula

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

            //audioSource.PlayOneShot(clipToPlay); nesne ayn� anda yok oldu�u i�in �al��m�yor. hem yok olup hem de ses �alam�yor.
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position);  // bu kod yok olan nesneler i�in do�ru kullan�m.

            Destroy(gameObject);
            
        }        
    }

}
