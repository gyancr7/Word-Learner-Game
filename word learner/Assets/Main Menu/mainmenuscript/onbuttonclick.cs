//onbuttonclick script to detect the button clicked
// this script is attached to the buttons on the GUI Main Menu screen

using UnityEngine;
using UnityEngine.SceneManagement;

public class onbuttonclick : MonoBehaviour {

    //to store the background color to be used
    public static string setcolor; 

    //if red button is clicked
    public void onredclick(string scenename)
    {
        setcolor="red";
        SceneManager.LoadScene(scenename);
    }
    
    //if blue button is clicked
    public void onblueclick(string scenename)
    {
        setcolor = "blue";
        SceneManager.LoadScene(scenename);
    }

    //if green button is clicked
    public void ongreenclick(string scenename)
    {
        setcolor = "green";
        SceneManager.LoadScene(scenename);
    }

    //function to return the babkground color to be set 
    public string returncolor()
    {
        return setcolor;
    }
   
}
