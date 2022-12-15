using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public float jumpHeight;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public int numPickups;
  
    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody>();
        count = 0;
		SetCountText();
		winTextObject.SetActive(false);

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
        
        if (Input.GetKeyDown("space"))
		{
			Vector3 jump = new Vector3 (0.0f, jumpHeight, 0.0f);
			rb.AddForce (jump);
		}

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp"))
        {   
            other.gameObject.SetActive(false);
            count = count + 1;
			SetCountText();
        }
    }

    void SetCountText ()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 13) 
		{
			winTextObject.SetActive(true);
		}
	}

}
