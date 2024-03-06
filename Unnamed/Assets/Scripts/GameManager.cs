using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyBalls;
    public TextMeshProUGUI scoreText;
    private int count;
    public float startDelay = 2;
    public float repeatDelay = 2;
    private float spawnBoundaryX;
    private static float spawnPositionY;

    private BoxCollider2D floorCollider;
    // Start is called before the first frame update
    void Start()
    {
        floorCollider = GameObject.Find("Floor").GetComponent<BoxCollider2D>();
        spawnBoundaryX = floorCollider.bounds.extents.x;
        spawnPositionY = GameObject.Find("Roof").transform.position.y;

        InvokeRepeating("SpawnEnemyBall", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyBall()
    {
        Vector3 spawnPosition = CalculateSphereSpawnPos();
        //int spawnBall = UnityEngine.Random.Range(0, enemyBalls.Length);
        GameObject evilSphere = Instantiate(enemyBalls[0], spawnPosition, enemyBalls[0].transform.rotation);
        evilSphere.GetComponent<EvilSphereBehaviour>().CalculateSphereDirection();
    }

    private Vector3 CalculateSphereSpawnPos(){
        float spawnPositionX = UnityEngine.Random.Range(-spawnBoundaryX, spawnBoundaryX);
        return new Vector3(spawnPositionX, spawnPositionY, 0);
    }

    public void UpdateCounting(){
        count++;
        scoreText.text = "Count: " + count;
    }
}
