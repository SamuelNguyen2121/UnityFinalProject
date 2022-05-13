using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{

    [SerializeField]
    float bulletDamage;

    [SerializeReference]
   public playerHealth PlayerHealth;

    private void OnTriggerEnter(Collider other)
    { 
        //Destroy the bullet
        Destroy(gameObject);
    }
}
