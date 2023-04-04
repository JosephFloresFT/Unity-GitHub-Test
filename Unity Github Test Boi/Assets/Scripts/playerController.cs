using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //variables
    public GameObject player;
    public GameObject playerCenter;
    Rigidbody playerRB;
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpForce;
    float horzAxis;
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
        horzAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");

        player.transform.Translate(playerCenter.transform.forward * vertAxis * moveSpeed * Time.deltaTime);
        //player.transform.Translate(Vector3.left * horzAxis * moveSpeed * Time.deltaTime);

        playerCenter.transform.Rotate(Vector3.up * horzAxis * rotationSpeed * Time.deltaTime);
        
        //tryna make em jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
