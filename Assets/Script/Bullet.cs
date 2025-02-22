using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;

    private void OnCollisionEnter(Collision objectWeHit)
    {
        //if (objectWeHit.gameObject.CompareTag("Target"))
        //{
        //    print("hit a target");
        //    CreateBulletImpactEffect(objectWeHit);
        //    Destroy(gameObject);
        //}

        //if (objectWeHit.gameObject.CompareTag("Wall"))
        //{
        //    print("hit a wall");
        //    CreateBulletImpactEffect(objectWeHit);
        //    Destroy(gameObject);
        //}

        //if (objectWeHit.gameObject.CompareTag("Bottle"))
        //{
        //    print("hit a bottle");
        //    objectWeHit.gameObject.GetComponent<BrokenBottle>().Shatter();

        //    // We will not destroy the bullet on impact, it will get destroyed according to its lifetime
        //}

        if (objectWeHit.gameObject.CompareTag("Enemy"))
        {
            print("hit a zombie");

            if (objectWeHit.gameObject.GetComponent<Enemy>().isEnemyDead == false)
            {
                objectWeHit.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            }
            CreateBloodSprayEffect(objectWeHit);
            Destroy(gameObject);

            // We will not destroy the bullet on impact, it will get destroyed according to its lifetime
        }
    }

    private void CreateBloodSprayEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject bloodSprayPrefab = Instantiate(
            GlobalReferences.Instance.bloodSprayEffect,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );

        bloodSprayPrefab.transform.SetParent(objectWeHit.gameObject.transform);
    }

    //void CreateBulletImpactEffect(Collision objectWeHit)
    //{
    //    ContactPoint contact = objectWeHit.contacts[0];

    //    GameObject hole = Instantiate(
    //        GlobalReferences.Instance.bulletImpactEffectPrefab,
    //        contact.point,
    //        Quaternion.LookRotation(contact.normal)            
    //        );

    //    hole.transform.SetParent(objectWeHit.gameObject.transform);
    //}


}
