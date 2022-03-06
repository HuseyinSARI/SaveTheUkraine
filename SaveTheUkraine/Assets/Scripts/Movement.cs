using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
     Rigidbody rigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
    }

    private void TakeInput()
    {
        //Left-Rigth
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3( (speed*100) * Time.deltaTime , rigidbody.velocity.y, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3((-speed * 100) * Time.deltaTime , rigidbody.velocity.y, 0);
        }
        else
        {
            
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, (jumpPower * 100) * Time.deltaTime , 0);
            
        }
        else
        {
            //print("Not Jump");
        }

    }
}
