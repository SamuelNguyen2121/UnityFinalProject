using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float leftSide, rightSide;

    bool direction = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (transform.position.x < leftSide || transform.position.x > rightSide)
        {
            direction = !direction;
          
        }

        if (direction)
        {
            transform.Translate(new Vector2(.2f, 0));


        }
        else
        {
            transform.Translate(new Vector2(-.2f, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}