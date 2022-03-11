using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbodyRef;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoints;

    private void Awake()
    {
        rigidbodyRef = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        TakeInput();
        
    }

    private void TakeInput()
    {
        //Left-Rigth
        if (Input.GetKey(KeyCode.A))
        {
            rigidbodyRef.velocity = new Vector3(Mathf.Clamp((speed*100) * Time.deltaTime,0f,15f) , rigidbodyRef.velocity.y, 0);
            // rigidbodyRef.rotation = Quaternion.Euler(0f, 180f,0f) ;  // hard rotation turn
            rigidbodyRef.rotation = Quaternion.Lerp(rigidbodyRef.rotation, Quaternion.Euler(0f, 179.99f, 0f), turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbodyRef.velocity = new Vector3(Mathf.Clamp((-speed * 100) * Time.deltaTime,-15f,0f) , rigidbodyRef.velocity.y, 0);
            // rigidbodyRef.rotation = Quaternion.Euler(0f, 0, 0f); // hard rotation turn
            rigidbodyRef.rotation = Quaternion.Lerp(rigidbodyRef.rotation, Quaternion.Euler(0f, 0.01f, 0f), turnSpeed * Time.deltaTime);

        }
        else
        {
            rigidbodyRef.velocity = new Vector3(0f, rigidbodyRef.velocity.y, 0f);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && OnGroundCheck() )
        {
            rigidbodyRef.velocity = new Vector3(rigidbodyRef.velocity.x, Mathf.Clamp((jumpPower * 100) * Time.deltaTime,0,15) , 0);
            
        }
        else
        {
            //print("Not Jump");
        }
    }

    private bool OnGroundCheck()
    {
        bool hit = false;

        for (int i = 0; i < rayStartPoints.Length; i++)
        {
            hit = Physics.Raycast(rayStartPoints[i].position, Vector3.down, 0.25f);
            Debug.DrawRay(rayStartPoints[i].position, Vector3.down * 0.25f, Color.red);
        }
         
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
