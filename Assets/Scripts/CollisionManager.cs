using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CollisionManager : MonoBehaviour
{
    private Damage damage;
    

    /*    private void Start()
        {

        }
        // Start is called before the first frame update
        private void OnCollisionEnter(Collision collision)
        {
            CapsuleCollider capsuleCollider = collision.transform.GetComponent<CapsuleCollider>();
            if(collision.transform.tag == "Enemy")
            {
                Physics.IgnoreCollision(gameObject.GetComponent<CharacterController>(), capsuleCollider);
            }

        }*/



    /*private void OnCollisionEnter(Collision collision)
    {
        if (damage.is && collision.transform.tag== "Enemy")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<CharacterController>(), collision.transform.GetComponent<CapsuleCollider>());
        }
        
    }*/
}
