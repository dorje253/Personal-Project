using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 100.0f;
    private float zBound = 5;

    private Rigidbody playerRb;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
        
    }

    // move the player based arrow key 
    void MovePlayer(){
        float horziontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput );
        playerRb.AddForce(Vector3.right * speed * horziontalInput );
    }

    // prevent the player the leaving the top or botton screen
    void ConstrainPlayerPosition(){
         if(transform.position.z < -zBound){
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
         if(transform.position.z > zBound){
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }


     private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy")){
            Debug.Log("Player has collided with enemy");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Powerup")){
            Destroy(other.gameObject);
        }
    }
}
