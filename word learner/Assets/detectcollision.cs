//script to detect collision and instansiate new alphabets if the alphabet hit by the bullet is correct
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class detectcollision : MonoBehaviour {

   // public GameObject fspawn;
    public GameObject fallobjprefab;
    static bool destroyed,letupdate;
    static int i=0,wordsize;
    GameObject alphref,fallobj,retobjec,finalresob;
    char[] selword;
    string selected;

    //if collision happened
    private void OnCollisionEnter(Collision collision)
    {
        //if the bullet hit the correct target alphabet
        //spawn next alphabet
        if (collision.gameObject.tag == "correct")
        {
            print("success!!");
            Destroy(GameObject.FindGameObjectWithTag("correct"));
            GameObject[] objs;
            objs = GameObject.FindGameObjectsWithTag("incorrect");

            foreach (GameObject obj in objs)
            {
                Destroy(obj);
            }
            finalresob = GameObject.Find("finalres");
            finalresob.GetComponent<Text>().text = "good correct alphabet!!";
            //StartCoroutine(ExecuteAfterTime(1000.0f));
            gamelogic();
            
        }

        //if the bullet hits wrong alpahbet
        //display wrong alphabet hit!! message
        else if (!(collision.gameObject.name.Contains("bullet")))
        {
            print(collision.gameObject.name);
            Destroy(GameObject.FindGameObjectWithTag("correct"));
            GameObject[] objs;
            objs = GameObject.FindGameObjectsWithTag("incorrect");

            foreach (GameObject obj in objs)
            {
                Destroy(obj);
            }
            letupdate = true;
            finalresob = GameObject.Find("finalres");
            finalresob.GetComponent<Text>().text="oops!! wrong alphabet";
            //StartCoroutine(ExecuteAfterTime(1000.0f));
            //SceneManager.LoadScene("GameRound");
        }
            
    }
    
    //for deleay
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        

    }
    
    //gamelogic to spawn next alphabet
    void gamelogic()
    {
         if(selected!=null)
        {
          char ch = getnext();
            if (ch != '#')
            {
                instansiatealpha(ch);
            }

        }

    }

    //get next xharacter of the selected word from the dropdown.
    char getnext()
    {
        i++;
        if (i < wordsize)
            return selword[i];
        else
            return '#';


    }
    
    void Start ()
    {
        selected = GameObject.Find("scripts").GetComponent<question>().returnselword();
        print(selected);
        selword = selected.ToCharArray();
        wordsize = selected.Length;
        print(wordsize);
        
    }


    //instansiate 3 new falling alphabet spheres and assign one of the correct alphabet to be hit by the player.
    void instansiatealpha(char ch)
    {
        Destroy(GameObject.FindGameObjectWithTag("correct"));
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("incorrect");

        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        char c = ch;
        print(ch);
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
        alphref.tag = "correct";
        alphref.GetComponent<TextMesh>().text = otherrandchar.ToString();
    }
  
	void Update () {

      
    }
}
