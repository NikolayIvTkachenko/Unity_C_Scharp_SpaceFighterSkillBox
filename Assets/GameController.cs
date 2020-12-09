using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menuGame;

    public static int score = 0;

    public UnityEngine.UI.Text scoreLabel;

    public UnityEngine.UI.Button startButton;

    public static bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate {

            menuGame.SetActive(false);
            isStarted = true;
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score;
    }
}
