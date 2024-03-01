using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float playerSpeed;
    public float currentSpeed;
    private float xBoundaries;

    // Start is called before the first frame update
    void Start()
    {
        xBoundaries = GameObject.Find("Floor").GetComponent<Collider2D>().bounds.extents.x - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        currentSpeed = playerSpeed;

        if((transform.position.x <= -xBoundaries && horizontalInput < 0) || (transform.position.x >= xBoundaries && horizontalInput > 0)){
            currentSpeed = 0;
        }
        
        transform.position += Vector3.right * currentSpeed * horizontalInput * Time.deltaTime;
    }
}
