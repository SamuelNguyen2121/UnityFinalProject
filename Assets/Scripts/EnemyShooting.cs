using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{


    //[SerializeField]
    //float bulletSpeed;

    public Rigidbody bullet;
    public Transform gun;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyShooting();
        Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);


    }

    void enemyShooting()
    {
        Ray ray = new Ray(transform.position, transform.forward * 100);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 1f, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                LaunchBullet();
            }
        }

        void LaunchBullet()
        {
            Rigidbody enemyBullet;
            enemyBullet = Instantiate(bullet, gun.position, gun.rotation);
            enemyBullet.AddForce(gun.forward * 30, ForceMode.Impulse);
            Destroy(enemyBullet.gameObject, 1f);
        }
    }
}
   

