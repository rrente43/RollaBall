using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //hold reference in script
    private Rigidbody rb;
  
    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody>();

    }
    //InputValue is variable type
    //void OnMove(InputValue movementValue){
    //    Vector2 movementVector = movementValue.Get<Vector2>();
    //    movementX = movementVector.x;
    //    movementY = movementVector.y;
    //}

    void FixedUpdate(){
        float movementX = Input.GetAxis ("Horizontal");
        float movementY = Input.GetAxis ("Vertical");

        //vector 3 variables xyz
        Vector3 movement = new Vector3 (movementX, 0.0f ,movementY);
        //Applying Force
        rb.AddForce (movement * speed);

    }

}
