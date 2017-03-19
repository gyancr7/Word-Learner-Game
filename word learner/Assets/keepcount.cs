//script to count the number of games played and store it in registry
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class keepcount : MonoBehaviour {
    static int count, last;
   
    GameObject obj;
    void Start()
    {
        print(PlayerPrefs.GetInt("nooftimesplayed"));
        obj = GameObject.Find("noofgamesplayed");
    }
     void Update()
    {
        count = PlayerPrefs.GetInt("nooftimesplayed");
       int  gamesplayed = count;
        obj.GetComponent<Text>().text="Games Played: "+(gamesplayed).ToString();
    }
    void Awake()
    {//take the last count from the file
        last = PlayerPrefs.GetInt("nooftimesplayed");
        PlayerPrefs.SetInt("nooftimesplayed", last+1);
    }
}
