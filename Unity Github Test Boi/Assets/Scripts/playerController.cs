using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //variables
    public GameObject player;
    Rigidbody playerRB;
    public float moveSpeed = 10.0f;
    public float rotationSpeed;
    public float boostMulti = 2;
    float horizAxis;
    float vertAxis;
    bool isOnGround;
    public float jumpHeight;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
        isOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        //tryna make em move
        horizAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && isOnGround)
        {
            moveSpeed = 25.0f;
        }
        else
        {
            moveSpeed = 10.0f;
        }
        

        player.transform.Translate(Vector3.forward * moveSpeed * vertAxis * Time.deltaTime);
        player.transform.Rotate(Vector3.up * rotationSpeed * horizAxis * Time.deltaTime);
        

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }   

         
        
    }

    void OnCollisionEnter()
    {
        isOnGround = true;
    }

    void OnCollisionExit()
    {
        isOnGround = false;
    }
}
