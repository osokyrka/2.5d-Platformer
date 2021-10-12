using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText, _livesText, _levelComplete, _timer;
    private void Start()
    {
        _levelComplete.gameObject.SetActive(false);
    }
    public void UpdateCoinDisplay(int coins)
    {
        _coinText.text = "ORBS: " + coins;
    }
    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "LIVES: " + lives;
    }
    public void UpdateLevel()
    {
        _levelComplete.gameObject.SetActive(true);
    }
    public void UpdateTimer(float time)
    {
        _timer.text = "TIME: " + time;
    }
}
