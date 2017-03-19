//script for inisialising question and words list and checking if the submitted answer is correct.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class question : MonoBehaviour {

    GameObject alphref;
    public GameObject fallobjprefab;
    List<string> quest;
    List<string> ans;
    GameObject oref,retry,contnue,submit,gunref;
    public string selword;
    public static bool submitted,contclicked;

	// Use this for initialization
	void Start () {

         //initialising question and answer lis new questions and answers can be added here.
        quest = new List<string>() { "","sunday comes before", "rose is a","christmas comes in","we should speak","we play" };
        ans = new List<string>() { "select","monday","flower","December","truth","games" };
        oref = GameObject.Find("option");
        oref.GetComponent<Dropdown>().ClearOptions();
        oref.GetComponent<Dropdown>().AddOptions(ans);
        oref = GameObject.Find("Question");
        System.Random rnd = new System.Random();
        int randint = rnd.Next(1,quest.Count);
        oref.GetComponent<Text>().text = quest[randint];
        submitted = false;
        contclicked = false;
        retry = GameObject.Find("retrybutton");
        contnue = GameObject.Find("continuebutton");
        submit = GameObject.Find("submitbutton");
        gunref = GameObject.Find("guncube");
        
       
	}

    //on submit button click.Logic t0 check if the selected answer corresponds to right question i.e.if answer is correct.
    public void onsubmitclick()
    {
        submitted = true;
        int qindex, aindex;
        oref = GameObject.Find("Question");
        string qeston = oref.GetComponent<Text>().text.ToString();
        qindex = quest.FindIndex(a => a.Equals(qeston));
        oref = GameObject.Find("option");
        aindex = oref.GetComponent<Dropdown>().value;
        selword = ans[aindex];
        if (qindex == aindex)
        {
            contnue.SetActive(true);
            retry.SetActive(false);
            submit.SetActive(false);
            oref = GameObject.Find("result");
            oref.GetComponent<Text>().text = "Correct!!";
        }

        else
        {
            contnue.SetActive(false);
            retry.SetActive(true);
            submit.SetActive(false);
            oref = GameObject.Find("result");
            oref.GetComponent<Text>().text = "Inorrect!!";
        }
            
    }

    //on retry button click load the GameRound scene.
    public void retryclick()
    {
        SceneManager.LoadScene("GameRound");

    } 
     //when continue button is clicked fallinf sphreres of alphabets are spawned. 
    public void oncontinueclick()
    {
        contnue.SetActive(false);
        oref = GameObject.Find("Question");
        oref.SetActive(false);
        oref = GameObject.Find("QuestionText");
        oref.SetActive(false);
        oref = GameObject.Find("option");
        oref.SetActive(false);
        oref = GameObject.Find("result");
        oref.SetActive(false);
        contclicked = true;
        gunref.SetActive(true);
        char ch = selword[0];
        instansiatealpha(ch);
       
    }

    //return selected word from the dropdown.
    public string returnselword()
    {
        return (selword);
    }
    //go back to main menu on button click.
    public void backtomain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //method to instansiate falling alphabets.
    //any one of the three falling spheres is chosen randomly and one correct alphabet from the selected word is assigned.
    //for remaining two falling spheres random alphabests are chosen anfd assigned.
    void instansiatealpha(char ch)
    {
        char c = ch;
        GameObject fallobjtemp;
        fallobjtemp = Instantiate(fallobjprefab) as GameObject;
        System.Random rnd = new System.Random();
        int randomint = rnd.Next(0, 3);
        char randchar = (char)('a' + randomint);
        char usedchar1 = randchar;
        alphref = GameObject.Find("Text" + randchar.ToString());
        alphref.GetComponent<TextMesh>().text = c.ToString();
        alphref.tag = "correct";
        while (randchar == usedchar1)
        {
            randomint = rnd.Next(0, 3);
            randchar = (char)('a' + randomint);
        }
        char usedchar2 = randchar;
        int otherrandomint = rnd.Next(0, 26);
        char otherrandchar = (char)('a' + otherrandomint);
        alphref = GameObject.Find("Text" + randchar.ToString());
        alphref.GetComponent<TextMesh>().text = otherrandchar.ToString();
        alphref.tag = "incorrect";
        while (randchar == usedchar2 || randchar == usedchar1)
        {
            randomint = rnd.Next(0, 3);
            randchar = (char)('a' + randomint);
        }
        otherrandomint = rnd.Next(0, 26);
        otherrandchar = (char)('a' + otherrandomint);
        alphref = GameObject.Find("Text" + randchar.ToString());
        alphref.tag = "incorrect";
        alphref.GetComponent<TextMesh>().text = otherrandchar.ToString();
    }

    // Update is called once per frame
    void Update () {

    
        if (!submitted)
        {
            retry.SetActive(false);
            contnue.SetActive(false);
            submit.SetActive(true);
        }

        if (!contclicked)
            gunref.SetActive(false);
    }
}
