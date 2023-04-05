using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject instructionButton, gameOverPanel;

    [SerializeField]
    Text scoreText;

    private void Awake()
    {
        PauseGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void InstructionButton()
    {
        instructionButton.SetActive(false);
        Resume();
    }

    public void ShowGameOverPanel(bool status)
    {
        gameOverPanel.SetActive(status);
    }

    public void SetScoreText(int score)
    {
        scoreText.text = $"Score : {score}";
    }

    public void RestarGame()
    {
        gameOverPanel?.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
