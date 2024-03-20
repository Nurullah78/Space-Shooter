using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Text scoreText, gameOverText, restartText, quitText;
    
    public float spawnWait, startSpawn, waveWait;
    public int spawnCount;
    
    private int _score;

    private bool _gameOver, _restart;

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startSpawn);

        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 9.5f);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            
            yield return new WaitForSeconds(waveWait);
            
            if (_gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                quitText.text = "Press 'Q' for Quit";
                _restart = true;
                break;
            }
        }
    }

    void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        _gameOver = false;
        _restart = false;
        StartCoroutine(SpawnValues());
    }

    public void UpdateScore()
    {
        _score += 10;
        scoreText.text = "Score: " + _score;
    }
    
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        _gameOver = true;
    }
    
    void Update()
    {
        if (_restart)
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
