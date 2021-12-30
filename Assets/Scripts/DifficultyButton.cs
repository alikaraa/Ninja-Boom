using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int diffuculty;

    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDiffuculty);
    }

    
    void Update()
    {
        
    }

    void SetDiffuculty(){
        Debug.Log(button.gameObject.name + "was clicked");
        gameManager.StartGame(diffuculty);
    }
}
