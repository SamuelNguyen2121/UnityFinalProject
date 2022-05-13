using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health = 100f;

    private Rigidbody enemyRB;

    public Ray rayShot;

    // Start is called before the first frame update
    private void Start()
    {
        enemyRB = GetComponent<Rigidbody>();

    }
    public void enemyDamage(float damage)
    {
        //Reduce the enemy health
        health -= damage;

    }
}




