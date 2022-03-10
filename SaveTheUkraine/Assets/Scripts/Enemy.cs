using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float shootRange = 10f;
    [SerializeField] private LayerMask shootLayer;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private float reloadTime = 3f;

    private bool canMoveRigth = false;
    private bool isReloaded = false;

    private Attack attackRef;
    void Start()
    {
        attackRef = GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAttack();

        CheckCanMoveRigth();

        MoveTowards();

        Aim();
    }

    private void Reload()
    {
        attackRef.GetAmmo = attackRef.GetClipSize;
        isReloaded = false;
    }

    private void EnemyAttack()
    {
        if(attackRef.GetAmmo <= 0 && !isReloaded)
        {
            Invoke(nameof(Reload), reloadTime);
            isReloaded = true;
        }
        if (attackRef.GetCurrentFireRate <= 0f && attackRef.GetAmmo > 0 && Aim())
        {
            attackRef.Fire();
        }
    }

    private bool Aim()
    {
        bool hit = Physics.Raycast(aimTransform.position, -transform.right, shootRange,shootLayer);
        Debug.DrawRay(aimTransform.position, -transform.right * shootRange, Color.blue);

        return hit;
        
    }
    private void MoveTowards()
    {
        //düþman ateþ ederken ilerlememesi için
        if(Aim() && attackRef.GetAmmo > 0)
        {
            return;
        }

        if (!canMoveRigth)
        {
            transform.position = Vector3.MoveTowards(transform.position
                                                     ,new Vector3( movePoints[0].position.x
                                                                   ,transform.position.y
                                                                   ,movePoints[0].position.z)
                                                     ,speed * Time.deltaTime);
            LookAtTheTarget(movePoints[0].position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position
                                                     , new Vector3(movePoints[1].position.x
                                                                   , transform.position.y
                                                                   , movePoints[1].position.z)
                                                     , speed * Time.deltaTime);
            LookAtTheTarget(movePoints[1].position);
        }
    }
    private void CheckCanMoveRigth()
    {
        if(Vector3.Distance(transform.position,movePoints[0].position) <= 0.1f){
            canMoveRigth = true;
        }
        else if (Vector3.Distance(transform.position, movePoints[1].position) <= 0.1f)
        {
            canMoveRigth = false;
        }
    }

    private void LookAtTheTarget(Vector3 newTarget)
        {
        Vector3 newLookPosition = new Vector3(newTarget.x, transform.position.y, newTarget.z);

        Quaternion _quaOffset = Quaternion.AngleAxis(90, Vector3.up); 

        Quaternion targetLocation = Quaternion.LookRotation((newLookPosition - transform.position)) * _quaOffset;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetLocation, speed * Time.deltaTime) ;

        }
}

