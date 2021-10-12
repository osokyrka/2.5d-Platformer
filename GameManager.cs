using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager = null;
    private Boss _boss = null;
    private float _time = 0.0f;
    private bool _counting = true;
    [SerializeField]
    private Button _playButton, _quitButton, _resumeButton;


    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _boss = GameObject.Find("Boss").GetComponent<Boss>();
        PauseGame();
        
    }

    private void Update()
    {
        Timer();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void Timer()
    {
        if(_counting == true)
        {
            _time += Time.deltaTime;
            _uiManager.UpdateTimer(_time);
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        _counting = false;
        _playButton.gameObject.SetActive(true);
        _quitButton.gameObject.SetActive(true);
        _resumeButton.gameObject.SetActive(true);
        Cursor.visible = true;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        _counting = true;
        Cursor.visible = false;
        _playButton.gameObject.SetActive(false);
        _quitButton.gameObject.SetActive(false);
        _resumeButton.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
