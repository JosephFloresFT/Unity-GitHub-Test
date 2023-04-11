using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //variables
    public GameObject player;
    Rigidbody playerRB;
    public float moveSpeed;
    public float rotationSpeed;
    float horizAxis;
    float vertAxis;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        //tryna make em move
        horizAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");

        player.transform.Translate(Vector3.forward * moveSpeed * vertAxis * Time.deltaTime);
        player.transform.Rotate(Vector3.up * rotationSpeed * horizAxis * Time.deltaTime);    

        if(player.transform.rotation.x > 90 || player.transform.rotation.x < 0)
        {
            Debug.Log("Yes");
        }    
        
    }
}
