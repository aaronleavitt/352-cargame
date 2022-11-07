using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

        [SerializeField] float steerSpeed = 100f;
        [SerializeField] float moveSpeed = 5f;

    void Start()
    {

    }


    void Update()
    {
        float steerSideways = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float steerUp = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
       
        transform.Rotate(0,0, -steerSideways);
        transform.Translate(0, steerUp,0);
      
    }
}
