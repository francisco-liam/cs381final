using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab;

    GameObject enemyProjectile;
    Vector3 distance;
    float shootTimer;
    float bufferTime;
    
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = 0;
        bufferTime = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position - player.transform.position;

        if(distance.magnitude < 7.5)
        {
            transform.LookAt(player.transform);
            if(shootTimer == bufferTime)
            {
                enemyProjectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
                enemyProjectile.GetComponent<Rigidbody>().AddForce(transform.forward*500);
                bufferTime = Random.Range(3f, 5f);
                shootTimer = 0;
            }
        }

        shootTimer += Time.deltaTime;

        if(shootTimer > bufferTime)
        {
            shootTimer = bufferTime;
        }

    }
}
