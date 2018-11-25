using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CommanLine : MonoBehaviour {

    string path;

    public Text Code;

    public Text PopUpText;

    public Text HackName;

    StreamReader reader;

    //public GameObject scrollObject;

    [SerializeField]
    private int pointsUpperLimit;

    [SerializeField]
    private int points;

    public GameObject ThePopUp;
    public RectTransform theCanvas;

    //private GameObject input;

    

    
    bool popUpSpawned;

    private string[] hacks = new string[] {"penetrator.exe", "FinnishHorse", "Back Burner", "1337Hackz.exe", "JunctiOff", "Minecraft.exe",
    "DumpBTC","Sminem.zip", "Bogdanoff.dll", "HDDBomber.std", "wondowsUpdate.exe", "BitConnect.ponzi", "EncryptArray.rar", "Mded.cli",
    "rsbuddy.jar", "delsys32", "tree/f/a", "norton.exe", "Ask_Toolbar", "BonziBUDDY", "freeRAM.net", "cmd.exe", "mspaint.exe", "freepunjabimovie_2018.phl",
    "voiceoverpete", "gamers.riseup", "Denzuko.b"};

    private int hackIterator;

    private int chosenHack;

    public GameObject Hacker;
   

    // Use this for initialization
    void Start () {
		path = "Assets/code.txt";
        reader = new StreamReader(path);
        pointsUpperLimit = Random.Range(80,120);
        points = 0;
        
        
        popUpSpawned = false;
        hackIterator = 0;
        Random.InitState(System.DateTime.Now.Millisecond); 
        //ThePopUp.SetActive(false);
        Hacker = GameObject.Find("Hacker");
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2)) {
            

            if(points < pointsUpperLimit) {
                WriteCodeToCommandLine();
                points += 1;
            } else if(points >= pointsUpperLimit) {
                HackPopUp();
            }
  
            
        }
	}

    void WriteCodeToCommandLine() {
        for(int i = 0; i < 3; i++) {
            int cInt = reader.Read();
            if(cInt == -1) {
                reader.Close();
                reader = new StreamReader(path);
            }

            char c = (char)cInt;
            Code.text = Code.text + c;

        }
    }

    void HackPopUp() {
        if(popUpSpawned == false && points >= pointsUpperLimit) {
            chosenHack = Random.Range(0,hacks.Length);
          
            ThePopUp.SetActive(true);
            popUpSpawned = true;
            HackName.text = hacks[chosenHack];
        }

        if(hackIterator >= hacks[chosenHack].Length-1) {
            popUpSpawned = false;
            
            hackIterator = 0;
            points = 0;
            PopUpText.text = "";
            pointsUpperLimit = Random.Range(80,120);
            ThePopUp.SetActive(false);
            Hacker.GetComponent<Hacker>().AddProgress(hacks[chosenHack].Length*0.65f);
        } else {
            foreach(char c in Input.inputString) {
                Debug.Log(hacks[chosenHack]);
                if(c == hacks[chosenHack][hackIterator]) {
                    PopUpText.text += c;
                    hackIterator++;
                }

            }
        }


    }


}


