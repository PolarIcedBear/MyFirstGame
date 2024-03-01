using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyBalls;
    public float startDelay = 2;
    public float repeatDelay = 2;
    public float spawnBoundaryX;
    private float spawnPositionY = 20;
    private BoxCollider2D floorCollider;
    // Start is called before the first frame update
    void Start()
    {
        floorCollider = GameObject.Find("Floor").GetComponent<BoxCollider2D>();
        spawnBoundaryX = floorCollider.bounds.extents.x;
        InvokeRepeating("SpawnEnemyBall", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyBall()
    {
        float spawnPositionX = UnityEngine.Random.Range(-spawnBoundaryX, spawnBoundaryX);
        Vector3 spawnPosition = new Vector3(spawnPositionX, spawnPositionY, 0);
        int spawnBall = UnityEngine.Random.Range(0, enemyBalls.Length);
        GameObject evilBall = Instantiate(enemyBalls[spawnBall], spawnPosition, enemyBalls[spawnBall].transform.rotation);
        evilBall.GetComponent<EvilSphereBehaviour>().ballXSpeed = UnityEngine.Random.Range(-5, 5);
        double xBallSpeed = evilBall.GetComponent<EvilSphereBehaviour>().ballXSpeed;
        evilBall.GetComponent<EvilSphereBehaviour>().ballYSpeed = (float)Math.Sqrt(Math.Pow(Math.Sqrt(50), 2) - Math.Pow(xBallSpeed, 2));
    }
}
