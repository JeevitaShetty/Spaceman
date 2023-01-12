using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, lifeText;
    [SerializeField] spacemanScript spaceScript;
    // Start is called before the first frame update
    void Start()
    {
        pauseGame();
    }

    // Update is called once per frame
    void Update()
    {
         int temp = spaceScript.lifeSetter();
        lifeText.text = "x" + temp.ToString() ;

        int temp1 = spaceScript.scoreSetter();
        scoreText.text = "Score:" + temp1.ToString();
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void playGame()
    {
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }

}

