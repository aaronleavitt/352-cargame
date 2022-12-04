using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Figure out how to change the asset of the sprite I have rendered it, and 

public class Driver : MonoBehaviour
{

        [SerializeField] float steerSpeed = 120f;
        [SerializeField] float waterSpeed = 7f;
        [SerializeField] float obstacleSpeed = 10f;
        [SerializeField] float moveSpeed = 14f;
        [SerializeField] float boostSpeed = 50f;

        float currentSpeed;
        
    public SpriteRenderer spriteRenderer;
    public Sprite YellowBus;
    public Sprite BlueCar;
    public Sprite Racer;
    void ChangeSprite(Sprite newSprite) {
        spriteRenderer.sprite = newSprite; 
    }

    void Start() {
        currentSpeed = moveSpeed;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Boost"){
            currentSpeed = boostSpeed;
            Destroy(other.gameObject, 0.2f);
        }
        if(other.gameObject.tag == "Water"){
            currentSpeed = waterSpeed;
        }
        if(other.gameObject.tag == "Big Boy"){
            gameObject.transform.localScale +=  new Vector3(1,1, 0);
            StartCoroutine(BigBoy(7));
            Destroy(other.gameObject, 0.2f);
        }
        if(other.gameObject.tag == "Lil Man"){
            gameObject.transform.localScale -=  new Vector3(0.2f,0.2f, 0);
            StartCoroutine(LilMan(7));
            Destroy(other.gameObject, 0.2f);
        } 
        if(other.gameObject.tag == "Bus"){
            ChangeSprite(YellowBus);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector3(2.5f,7, 0);
            StartCoroutine(Bussie(15));
            Destroy(other.gameObject, 0.2f);
        } 
        if(other.gameObject.tag == "Racer"){
            ChangeSprite(Racer);
            StartCoroutine(RacerCar(15));
            Destroy(other.gameObject, 0.2f);
        } 
   }

   private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Water"){
            currentSpeed = moveSpeed;
        }
   }
   
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Obstacle"){
            StartCoroutine(ObsSpeed(1.5f));
            currentSpeed = obstacleSpeed;
        }
    }

    IEnumerator LilMan(float time) {
     yield return new WaitForSeconds(time);
        gameObject.transform.localScale +=  new Vector3(0.2f,0.2f, 0);
    }

    IEnumerator BigBoy(float time) {
     yield return new WaitForSeconds(time);
        gameObject.transform.localScale -=  new Vector3(1,1, 0);
    }

    IEnumerator Bussie(float time) {
     yield return new WaitForSeconds(time);
            ChangeSprite(BlueCar);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector3(1.8f,3.495438f, 0);
    }
    
    IEnumerator RacerCar(float time) {
     yield return new WaitForSeconds(time);
            ChangeSprite(BlueCar);
    }

    IEnumerator ObsSpeed(float time) {
     yield return new WaitForSeconds(time);
         currentSpeed = moveSpeed;
    }

    void Update() {
        float steerSideways = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float steerUp = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
       
        transform.Rotate(0,0, -steerSideways);
        transform.Translate(0, steerUp,0);
      
    }
}
