using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float health = 100f;

    [SerializeField]
    Text healthOfPlayer;
    // Start is called before the first frame update

    private void Start()
    {
        healthOfPlayer.text = health.ToString();

        healthOfPlayer.color = Color.green;
    }
     
    
    private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.tag == "enemyBullet")
            {
                health -= 25;
                healthOfPlayer.text = health.ToString();

                if (health == 0)
                {
                    Debug.Log("Dead");
                    Time.timeScale = 0;
                    healthOfPlayer.color = Color.red;
                }

                if (health == 25)
                {
                    healthOfPlayer.color = Color.red;
                }
                else if (health == 50)
                {
                    healthOfPlayer.color = Color.yellow;
                }
                else
                {
                    healthOfPlayer.color = Color.green;
                }
                Destroy(other.gameObject);
            }
        }

    
}
