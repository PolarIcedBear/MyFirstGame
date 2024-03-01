using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EvilSphereBehaviour : MonoBehaviour
{
    public float ballYSpeed = 5;
    public float ballXSpeed = 5;
    public GameObject evilBallToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(ballXSpeed, ballYSpeed, 0) * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Floor")){
            ballYSpeed = -ballYSpeed;
        }
        else if(other.tag.Equals("SideWall")){
            ballXSpeed = -ballXSpeed;
        }
        else if(other.tag.Equals("PlayerPlatform")){
            if(gameObject.CompareTag("Big") || gameObject.CompareTag("Medium")){

                Instantiate(evilBallToSpawn, gameObject.transform);
            }
            Destroy(gameObject);
        }
        else if(other.tag.Equals("Player")){
            Destroy(other.gameObject);
        }
    }

    
}
