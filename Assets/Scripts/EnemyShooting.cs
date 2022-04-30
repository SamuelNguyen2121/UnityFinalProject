using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Rigidbody bullet;
    [SerializeField]
    Transform gun;

    [SerializeField]
    float speed = 1.0f;

    float firerate;
    float nextShoot;
    // Update is called once per frame
    private void Start()
    {
        nextShoot = Time.time;

        //Bullets shoot out every half a second 
        firerate = 0.5f;
    }
    void Update()
    {
        enemyShooting();

    }

    void enemyShooting()
    {
        Debug.DrawRay(gun.position, transform.forward * 100, Color.yellow);
        Ray ray = new Ray(gun.position, transform.forward * 100);
        RaycastHit hit;
        /*if (Physics.Raycast(ray, out hit))*/
        if (Physics.SphereCast(ray, 5f, out hit))
        {
            {
                if (hit.collider.tag == "Player")
                {
                    Vector3 targetDirection = target.position - transform.position;

                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection + new Vector3(0.3f, 0, 0), speed * Time.deltaTime, 0.0f);

                    // Draw a ray pointing at our player in
                    Debug.DrawRay(transform.position, newDirection * 100, Color.red);

                    transform.rotation = Quaternion.LookRotation(newDirection);

                    //FireRate Control
                    if (Time.time > nextShoot)
                    {

                        LaunchBullet();
                        nextShoot = Time.time + firerate;
                    }
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
}
   

