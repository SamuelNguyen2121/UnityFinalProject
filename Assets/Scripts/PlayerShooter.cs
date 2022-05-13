using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private Rigidbody hostageRB;

    [SerializeField]
    float hostageKillAmount;
    private EnemyShooting enemyShooting;

    [SerializeField]
    Transform muzzle;

    [SerializeField]
    GameObject muzzleFlash;



    [SerializeField] int totalEnemies = 38;

    // Start is called before the first frame update
    void Start()
    {
        enemiesText.text = "Total Enemies " + totalEnemies;
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();

    }
    public void Shoot()
    {
        GameObject playerMuzzle;

        if (Input.GetButtonDown("Fire1"))//Left mouse button
        {
            //Raycast forward from the main camera
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            playerMuzzle = Instantiate(muzzleFlash,  muzzle.position, muzzle.rotation);
            Destroy(playerMuzzle, 0.1f);

            RaycastHit hit;
            //Check for collision with a raycast of 100 units
            if (Physics.Raycast(ray, out hit, 100f))
            {
                //Get the "Damage" script on the enemy
                enemy = hit.transform.GetComponent<Damage>();

                //Get the Rigidbody
                enemyRB = hit.transform.GetComponent<Rigidbody>();

                //Get the "EnemyShooting" Script on the enemy
                enemyShooting = hit.transform.GetComponent<EnemyShooting>();


                //Check if the bullet hit a Hostage
                if(hit.transform.tag == "Hostage")
                {

                    hostageRB = hit.transform.gameObject.GetComponent<Rigidbody>();

                    //Add force to the hostage based on where the bullet hit them
                    hostageRB.AddForceAtPosition(ray.direction * deathForce, hit.point, ForceMode.Impulse);

                    hostageKillAmount -= 1;
                    if(hostageKillAmount == 0)
                    {
                        SceneManager.LoadScene("GameOverScene");
                    }

                }

                //Check if the enemy has a damage script attached 
                if (enemy != null)
                {

                    enemy.enemyDamage(damageAmount);

                    if(enemy.health == 0)
                    {
                        enemyRB.isKinematic = false;
                        
                        //Disable the enemyShooting script to stop an enemy from shooting when thhere dead
                        enemyShooting.enabled = false;

                        //Once helath is 0 or less it will launch the enemy based on the direction the ray hit it at
                        enemyRB.AddForceAtPosition(ray.direction * deathForce, hit.point, ForceMode.Impulse); 

                        //Destroy the enemy after 2 seconds
                        Destroy(hit.transform.gameObject, 2);
                        totalEnemies--;

                        //Update total enemies ttext in ui
                        enemiesText.text = "Total Enemies: " + totalEnemies;

                        if (totalEnemies == 0)
                        {
                            //Freeze time 
                            Time.timeScale = 0;
                            SceneManager.LoadScene("MissionCompletedScene");
                        }
                    }
                }
            }
        }
    }



    

}