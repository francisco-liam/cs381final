using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public int health;
    public float damageTimer;
    public float iTime;
    //public TextMeshProUGUI healthText;
    public GameObject heart2;
    public GameObject heart3;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        iTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(velocity * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            float gravY = Physics.gravity.y;
            Physics.gravity = new Vector3(1, -gravY, 1);
        }

<<<<<<< Updated upstream
        if(damageTimer < iTime)
=======


        if (damageTimer < iTime)
>>>>>>> Stashed changes
            damageTimer += Time.deltaTime;

        if (damageTimer > iTime)
            damageTimer = iTime;

        health = Mathf.Clamp(health, 0, 3);

        //healthText.text = "Health: " + health + "/3";

        if (health <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Damaging"))
        {
            if (damageTimer == iTime)
            {
                health--;
                damageTimer = 0;
            }
            if (health == 2)
            {
                heart3.SetActive(false);
            }
            if (health == 1)
            {
                heart2.SetActive(false);
            }
        }

        if (collision.collider.CompareTag("Gem"))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
