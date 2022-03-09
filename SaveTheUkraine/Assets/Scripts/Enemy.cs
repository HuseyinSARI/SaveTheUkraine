using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;

    private bool canMoveRigth = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanMoveRigth();
        MoveTowards();
    }
    private void MoveTowards()
    {
        if (!canMoveRigth)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[0].position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[1].position, speed * Time.deltaTime);

        }
    }
    private void CheckCanMoveRigth()
    {
        if(Vector3.Distance(transform.position,movePoints[0].position) <= 0.1f){
            canMoveRigth = true;
            print("move rigth");
        }
        else if (Vector3.Distance(transform.position, movePoints[1].position) <= 0.1f)
        {
            canMoveRigth = false;
            print("move left");
        }
    }
}

