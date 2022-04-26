using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{

    [SerializeField]
    float bulletDamage;

    [SerializeReference]
   public playerHealth PlayerHealth;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    { 
        Destroy(gameObject);
    }
}
