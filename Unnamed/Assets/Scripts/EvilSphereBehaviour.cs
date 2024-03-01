using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EvilSphereBehaviour : MonoBehaviour
{
    public float ballYSpeed;
    public float ballXSpeed;
    public GameObject evilBallToSpawn;
    private const float X_SPHERE_MAX_SPEED = 10;
    private const float Y_SPHERE_MAX_SPEED = 10;
    private static double sphereSpeed = Math.Sqrt(Math.Pow(X_SPHERE_MAX_SPEED, 2) + Math.Pow(Y_SPHERE_MAX_SPEED, 2));
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(ballXSpeed, ballYSpeed, 0) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
        switch(other.tag){
            case "Floor":
                ballYSpeed = -ballYSpeed;
                break;
            case "SideWall":
                ballXSpeed = -ballXSpeed;
                break;
            case "Weapon":
                /*if(gameObject.CompareTag("Big") || gameObject.CompareTag("Medium")){

                Instantiate(evilBallToSpawn, gameObject.transform);
                }*/
                Destroy(gameObject);
                break;
            case "player":
                Destroy(other.gameObject);
                break;
            default: break;
        }
    }

    public void CalculateSphereDirection(){
        gameObject.GetComponent<EvilSphereBehaviour>().ballXSpeed = UnityEngine.Random.Range(-10, 10);
        double xBallSpeed = gameObject.GetComponent<EvilSphereBehaviour>().ballXSpeed;
        gameObject.GetComponent<EvilSphereBehaviour>().ballYSpeed = (float)Math.Sqrt(Math.Pow(sphereSpeed, 2) - Math.Pow(xBallSpeed, 2));
    } 

    
}
