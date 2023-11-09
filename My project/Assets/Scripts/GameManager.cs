using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Enemy> enemies;
    public PlayerMovement player;
    public GameObject GameOverMenu;
    public TextMeshProUGUI goText;
    public PlayerLevel level;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void GameOver() //Call up the game over overlay.
    {
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
        goText.text = $"SCORE: {level.totalExp}";
    }
}
