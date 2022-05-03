using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rb;
    private float moveX;
    private float moveY;
    public float count = 0;
    public TextMeshProUGUI counter;
    public GameObject collectibles;
    public TextMeshProUGUI timer;
    private float timecount = 0;
    private float minute = 0;
    // private float hour = 0; 2much
    public GameObject victoryscreen;
    public GameObject defeatscreen;
    public GameObject spawnLocations;
    public GameObject enemyPrefab;
    public GameObject startButtton;
    public GameObject restartButton;
    public GameObject nextlevelButton;
    public GameObject TheHunter;
    public bool start = false;
    private bool won = false;
    public void StartGame()
    {
        start = true;
    }
    public void StopGame()
    {
        start = false;
    }
    void UpdateUI()
    {
        counter.text = "Collected: " + count.ToString() + "/" + (collectibles.transform.childCount);
    }

    void Start()
    {
        won = false;
        victoryscreen.SetActive(false);
        defeatscreen.SetActive(false);
        restartButton.SetActive(false);
        nextlevelButton.SetActive(false);

        counter.text = "Collected: " + count.ToString() + "/" + (collectibles.transform.childCount);
        rb = GetComponent<Rigidbody>();
        //Random.Range(0,1); minInclusive maxExclusive
    }

    void FixedUpdate()
    {

        if (speed < 0)
        {
            speed = 0;
        }
        if (speed > 75)
        {
            speed = 75;
        }

        if (won == false)
        {
            if (speed == 0)
            {
                defeatscreen.SetActive(true);
                restartButton.SetActive(true);
            }
        }
        if (won == true)
        {
            if (speed == 0)
            {
                defeatscreen.SetActive(false);
                restartButton.SetActive(false);
            }
        }

        if (timecount > 60)
        {
            minute = minute + 1;
            timecount = 0;
        }


        Vector3 movement = new Vector3(moveX, y:0, z:moveY);
        rb.AddForce(movement*speed);


        if (start)
        {
            timecount = timecount + Time.deltaTime;
            timer.text = (minute) + (":") + ((int)timecount).ToString();
        }
        
        if (timecount < 10)
        {
            timer.text = (minute) + (":0") + ((int)timecount).ToString();
        }
        if (count == collectibles.transform.childCount) //for victory
        {
            won = true;
            victoryscreen.SetActive(true);
            nextlevelButton.SetActive(true);
            restartButton.SetActive(true);
            timecount = timecount - Time.deltaTime;
        }
        
        

    }

    void SpawnEnemy()
    {
        Transform[] enemySpawns = spawnLocations.GetComponentsInChildren<Transform>();
        GameObject newEnemy = Instantiate(enemyPrefab, enemySpawns[0]);
        //newEnemy.transform.SetParent = spawnLocations;
    }
    
    
    void OnMove(InputValue movement)
    {
        if (start)
        {
            Vector2 movementVector = movement.Get<Vector2>();
            moveX = movementVector.x;
            moveY = movementVector.y;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            UpdateUI();
        }
        
        
        
        //rb.AddForce(new Vector3(0,500,0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.SetActive(false);
            speed = speed - 10;
        }

        if (collision.gameObject.CompareTag("boost"))
        {
            collision.gameObject.SetActive(false);
            speed = speed + 10;
        }

        if (collision.gameObject.CompareTag("bumpy"))
        {
            collision.gameObject.SetActive(false);
            Vector3 bump = new Vector3(0, y: 15, z: 0);
            rb.AddForce(speed * bump);
        }
    }
    
    

}
