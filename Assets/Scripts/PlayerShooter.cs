using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    float damageAmount;

   
    private Damage enemy;
    

    private Rigidbody enemyRB;
    [SerializeField]
    float deathForce;

    [SerializeField]
    Text enemiesText;

    [SerializeField]
    Canvas levelPassed;

    /*    [SerializeField]
        private CapsuleCollider enemyCapsuleCollider;*/

    [SerializeField]
    private CharacterController characterController;
    private int totalEnemies = 38; // <--- should be 38

    // Start is called before the first frame update
    void Start()
    {
        enemiesText.text = "Total Enemies " + totalEnemies;


    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 100f, Color.blue);
        Shoot();

    }
    public void Shoot()
    {

        if (Input.GetButtonDown("Fire1") /* || Input.GetButton("Fire1")*/)//Left mouse button
        {
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {

                enemy = hit.transform.GetComponent<Damage>();
                enemyRB = hit.transform.GetComponent<Rigidbody>();

                if (enemy != null)
                {
                    enemy.enemyDamage(damageAmount);

                    if(enemy.health == 0)
                    { 
                        enemyRB.AddForceAtPosition(ray.direction * deathForce, hit.point, ForceMode.Impulse); //Once helath is 0 or less it will launch the enemy based on the direction the ray hit it at
                        Destroy(hit.transform.gameObject, 2);
                        totalEnemies--;
                        enemiesText.text = "Total Enemies: " + totalEnemies;
                        if (totalEnemies == 0)
                        {

                            levelPassed.enabled = true;
                            Time.timeScale = 0;
                        }
                    }
                }
            }
        }
    }



    

}