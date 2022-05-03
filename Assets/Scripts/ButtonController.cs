using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerController player;
    public void Begin()
    {
        player = playerObject.GetComponent<PlayerController>();
        gameObject.SetActive(false);
        player.StartGame();
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "First Level")
        {
            GM.instance.LoadNextLevel("Second Level");
        }
        if (SceneManager.GetActiveScene().name == "Second Level")
        {
            GM.instance.LoadNextLevel("Third Level");
        }
        if (SceneManager.GetActiveScene().name == "Third Level")
        {
            GM.instance.LoadNextLevel("Fourth Level");
        }
        if (SceneManager.GetActiveScene().name == "Fourth Level")
        {
            GM.instance.LoadNextLevel("Fifth Level");
        }
        if (SceneManager.GetActiveScene().name == "Fifth Level")
        {
            GM.instance.LoadNextLevel("First Level");
        }
    }
    public void RestartLevel()
    {
        GM.instance.Reload();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
