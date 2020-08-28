using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    public GameObject lifeLost;
    public GameObject playerText;

    public static int playerScore;

    public void PlayerBallHit()
    {
        playerScore++;
        playerText.GetComponent<TextMeshProUGUI>().text = playerScore.ToString();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
