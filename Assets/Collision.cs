using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] Color hasPackageColor = Color.green;
    [SerializeField] Color noPackageColor = Color.white;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other) {
    Debug.Log("That's a crash my boy");
   }
   private void OnTriggerEnter2D(Collider2D other) {

    if(other.gameObject.tag == "Package" && !hasPackage){
        Debug.Log("Picked up a package");
        hasPackage = true;
        spriteRenderer.color = hasPackageColor;
        Destroy(other.gameObject, 0.2f);
    }
    else if(other.gameObject.tag == "Customer" && hasPackage){
        Debug.Log("Dropped off Package");
        spriteRenderer.color = noPackageColor;
        hasPackage = false;
    }
   }




}
