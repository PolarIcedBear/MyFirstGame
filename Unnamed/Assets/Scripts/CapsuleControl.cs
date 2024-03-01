using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour
{
    public float horizontalInput;
    public float horizontalSpeed;
    public float currentSpeed;
    private float xBoundaries;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);
        xBoundaries = GameObject.Find("Floor").GetComponent<Collider2D>().bounds.extents.x - 1;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal1");
        currentSpeed = horizontalSpeed;
        
        if((transform.position.x <= -xBoundaries && horizontalInput < 0) || (transform.position.x >= xBoundaries && horizontalInput > 0)){
            currentSpeed = 0;
        }

        transform.position += Vector3.right * currentSpeed * horizontalInput * Time.deltaTime;
    }
}
