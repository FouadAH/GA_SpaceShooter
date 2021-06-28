using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText; //this is the score text you see at the top of your screen
    public TMP_Text youLoseText; //this is the lose text you see when you lose
    public Button restartButton; //this is the restart button you'll click to restart the game

    public Slider gunHeat;

    public DamageEffect damageEffect;
    public int score = 0;

    public int healthGM;
    public GameObject healthBar;
    public GameObject healthIconPrefab;
    public Stack<GameObject> healthIcons = new Stack<GameObject>();

    public List<RandomSpawner> randomSpawners = new List<RandomSpawner>();
  
    public static GameManager instance; //this is called an instance. It's not a beginner's topic but to simplify it greatly, this is something that only exists once in all the game
    private void Awake()
    { 
        //and the code in this Awake function makes sure we only have one instance of the Game Manager all over
        //we need this because it's the one thing all aspects of the game will be talking to (eg we can have many bullets, but only one game manager)
        if(instance == null)
        {
            //set instance to this object
            instance = this;
        }
        else
        {
            //destroy the this object if another one like it exists
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (score >= 500 && score < 1000)
        {
            foreach (RandomSpawner randomSpawner in randomSpawners)
            {
                randomSpawner.timeToSpawn = 0.8f;
            }
        }
        else if (score >= 1000 && score < 1500)
        {
            foreach (RandomSpawner randomSpawner in randomSpawners)
            {
                randomSpawner.timeToSpawn = 0.6f;
            }
        }
        else if (score >= 1500 && score < 2000)
        {
            foreach (RandomSpawner randomSpawner in randomSpawners)
            {
                randomSpawner.timeToSpawn = 0.4f;
            }
        }
        else if (score >= 2000)
        {
            foreach (RandomSpawner randomSpawner in randomSpawners)
            {
                randomSpawner.timeToSpawn = 0.2f;
            }
        }
    }

    private void Start()
    {
        InitHealthBar();
    }

    public void InitHealthBar()
    {
        for (int i = 0; i < healthGM; i++)
        {
            GameObject healthIcon = Instantiate(healthIconPrefab, healthBar.transform);
            healthIcons.Push(healthIcon);
        }
    }

    public void InitScore()
    {
        scoreText.text = "0";
    }


    public void AddScore()
    {
        //Add the score. This function is called when we destroy an object with a bullet.
        //it takes the score from the score Text box, adds 10, then sets it back.
        score += 10;
        scoreText.text = score.ToString();
    }

    public void AddHealth(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject healthIcon = Instantiate(healthIconPrefab, healthBar.transform);
            healthIcons.Push(healthIcon);
        }
    }

    public void RemoveHealth(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (healthIcons.Count > 0)
                Destroy(healthIcons.Pop());
        }
    }
    
    public void LoseGame()
    {
        //Lose the game. This function is called when we lose the game.
        //it sets the you lose text and the restart buttons on screen.
        youLoseText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        //restarts the level. You need to put this function in the button for it to work.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
