using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private int bulletPower = 1;
    [SerializeField] private GameObject rocketFX;
    [SerializeField] private bool isRocket = false;
    public GameObject owner;

    public int GetBulletPower
    {
        get 
        { 
            return bulletPower; 
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rocketTail = transform.position;
        rocketTail = rocketTail + transform.up * -1/3;

        if (isRocket) Instantiate(rocketFX, rocketTail , Quaternion.identity);

        
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.GetComponent<Target>() == false)
        {
            Destroy(gameObject);
        }
    }
}
