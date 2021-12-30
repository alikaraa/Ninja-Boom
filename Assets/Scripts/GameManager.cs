using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;

    void Start()
    {

    }
    
    void Update()
    {
        
    }

    IEnumerator SpawnTarget(){
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        
        }
    }

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void GameOver(){
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int diffuculty){

            isGameActive = true;
            score = 0;
            spawnRate /= diffuculty;

            StartCoroutine(SpawnTarget());
            UpdateScore(0);
            titleScreen.gameObject.SetActive(false);
    }
}
