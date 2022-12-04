using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageMovement : MonoBehaviour
{
    int direction = 1;
    int counter = 0;
    int maxdistance = 100;
    float moveSpeed = 0.01f;


    void Update()
    {
        if(Mathf.Abs(counter) > maxdistance){
            direction = direction * -1;
        }

        transform.Translate(0,moveSpeed * direction, 0);

        if(direction > 0){
            counter--;
        } else {
            counter++;
        }


    }
}



