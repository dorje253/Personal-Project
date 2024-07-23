using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    private float zDestroy = -10.0f;
    private Rigidbody objectRb;
    void Start()
    {
        objectRb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if(transform.position.z < zDestroy){
            Destroy(gameObject);
        }
    }
}
