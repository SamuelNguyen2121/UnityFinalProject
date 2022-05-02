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

    [SerializeField]
    Canvas levelPassed;

    private Rigidbody hostageRB;

    [SerializeField]
    float hostageKillAmount;
    private EnemyShooting enemyShooting;

    [SerializeField]
    Transform muzzle;

    [SerializeField]
    GameObject muzzleFlash;


    /*    [SerializeField]
        private CapsuleCollider enemyCapsuleCollider;*/


    [SerializeField] int totalEnemies = 38; // <--- should be 38

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
        GameObject playerMuzzle;

        if (Input.GetButtonDown("Fire1") /* || Input.GetButton("Fire1")*/)//Left mouse button
        {
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            playerMuzzle = Instantiate(muzzleFlash,  muzzle.position, muzzle.rotation);
            Destroy(playerMuzzle, 0.1f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {

                enemy = hit.transform.GetComponent<Damage>();
                enemyRB = hit.transform.GetComponent<Rigidbody>();
                enemyShooting = hit.transform.GetComponent<EnemyShooting>();



                if(hit.transform.tag == "Hostage")
                {

                    hostageRB = hit.transform.gameObject.GetComponent<Rigidbody>();
                    hostageRB.AddForceAtPosition(ray.direction * deathForce, hit.point, ForceMode.Impulse);
                    Debug.Log("hostage hit");
                    hostageKillAmount -= 1;
                    if(hostageKillAmount == 0)
                    {
                        SceneManager.LoadScene("GameOverScene");
                    }

                }

                if (enemy != null)
                {

                    enemy.enemyDamage(damageAmount);

                    if(enemy.health == 0)
                    {
                        enemyRB.isKinematic = false;
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
                            levelPassed.enabled = true;
                            Time.timeScale = 0;
                        }
                    }
                }
            }
        }
    }



    

}