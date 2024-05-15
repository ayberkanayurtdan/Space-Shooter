using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

    public Text scoreText;
    public int score;

    public Text gameOverText;
    public Text restartText;
    public Text quitText;

    private bool gameOver;
    private bool restart;
    


    IEnumerator Spawnvalues()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                //Coroutine
                yield return new WaitForSeconds(spawnWait);
                //1-) IEnumarator döndürmek zorundadır
                //2-) En az 1 adet yield ifadesi bulunmalıdır
                //3-) Çağırılırken çağırılırken mutlaka StartCoroutine() metoduyla çağrılmalıdır!
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver == true)
            {
                restartText.text = "Press 'R' for Restart";
                quitText.text = "Press 'Q' for Quit";
                restart = true;
                break;
            }
        }   
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
    void Start()
    {
        StartCoroutine(Spawnvalues());
        gameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        gameOver = false;
        restart = false;
    }
    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
}
