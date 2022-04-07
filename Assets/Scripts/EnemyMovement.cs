using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private  Vector3 tagertPos;

    private  Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(startPos);


        transform.position = Vector3.MoveTowards(startPos, tagertPos, 0.5f);
        if (transform.position == tagertPos)
        {
            transform.position = Vector3.MoveTowards (tagertPos, startPos, -0.5f);
            
        }
 


    }




    /*IEnumerator LerpPosition(Vector3 target, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            
            time += Time.deltaTime;
            yield return null;


        }

        transform.position = target;
    }*/
}
