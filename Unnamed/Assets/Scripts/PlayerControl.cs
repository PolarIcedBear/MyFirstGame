using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float playerSpeed;
    public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        currentSpeed = playerSpeed;

        if((transform.position.x <= -9 && horizontalInput < 0) || (transform.position.x >= 9 && horizontalInput > 0)){
            currentSpeed = 0;
        }
        
        transform.position += Vector3.right * currentSpeed * horizontalInput * Time.deltaTime;
    }
}
