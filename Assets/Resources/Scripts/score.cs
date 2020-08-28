using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameObject.Find("finalScore").GetComponent<TextMeshProUGUI>().text = GameManager.playerScore.ToString();
        if (GameManager.playerScore > PlayerPrefs.GetInt("Highscore", 0)){
            PlayerPrefs.SetInt("Highscore", GameManager.playerScore);
        }
        GameObject.Find("highScore").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        GameManager.playerScore = 0;

    }

}
