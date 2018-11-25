using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    public enum GameState {
        Menu, Game, HackerWins, ItguyWins
    };

    public GameState state;

    private Hacker HackerObj;
    private Itguy ItguyObj;
    
    private GameObject wintext;

    void GameLoop() {
        //Start by adding passive action progress to Hacker and Itguy
        HackerObj.AddDurationProgress();
        ItguyObj.AddDurationProgress();
        //Change Player faces based on the progress
        HackerObj.ProgressFace(ItguyObj.Progress());
        ItguyObj.ProgressFace(HackerObj.Progress());
        //Check if either player has won
        if (HackerObj.IsActionFinished()) {
            Debug.Log("Hacker wins!");
            state = GameState.HackerWins;
        }
        else if (ItguyObj.IsActionFinished()) {
            Debug.Log("Itguy wins!");
            state = GameState.ItguyWins;
        }
    }

	// Use this for initialization
	void Start () {
        wintext = GameObject.Find("WinText");
        wintext.SetActive(false);
        state = GameState.Game;
        HackerObj = (Hacker)GameObject.Find("Hacker").GetComponent(typeof(Hacker));
        ItguyObj = (Itguy)GameObject.Find("Itguy").GetComponent(typeof(Itguy));
        HackerObj.ChangeFace(Player.Face.Normal);
        ItguyObj.ChangeFace(Player.Face.Normal);

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("escape")) {
            SceneManager.LoadScene(0);
        }
        switch (state) {
            case GameState.Menu:
                break;
            case GameState.Game:
                GameLoop();
                break;
            case GameState.HackerWins:
                Debug.Log("Hacker Wins");
                HackerObj.ChangeFace(Player.Face.Normal);
                ItguyObj.ChangeFace(Player.Face.Surprised);
                StartCoroutine(HackerWin());
                break;
            case GameState.ItguyWins:
                Debug.Log("Itguy Wins");
                HackerObj.ChangeFace(Player.Face.Surprised);
                ItguyObj.ChangeFace(Player.Face.Normal);
                StartCoroutine(ITWin());
                break;
            default:
                break;
        }     
	}
    IEnumerator HackerWin() {
        //wintext.transform.SetAsFirstSibling();
        wintext.GetComponent<Text>().text = "HACKER WINS!!!11";
        wintext.SetActive(true);
        yield return new WaitForSeconds(3);
        wintext.SetActive(false);
        SceneManager.LoadScene("HackerWin");
    }
    IEnumerator ITWin() {
        //wintext.transform.SetAsFirstSibling();
        wintext.GetComponent<Text>().text = "IT SUPPORT WINS!!!11";
        wintext.SetActive(true);
        yield return new WaitForSeconds(3);
        wintext.SetActive(false);
        SceneManager.LoadScene("ItguyWin");
    }

}
