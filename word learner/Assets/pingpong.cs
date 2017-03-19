// ping-pong script set the background color based on input from onbuttonclick script 
// pingpong.cs script is attached to the camera of the GameRound scene
using UnityEngine;

public class pingpong : MonoBehaviour
{
    
    public string getcolor;
    new Camera camera;

    void Start()
    {   //get the color of the button clicked on main menu
        getcolor = GameObject.Find("mainmenuscripts").GetComponent<onbuttonclick>().returncolor();
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;

        //set the background color
        if (getcolor == "red")
            camera.backgroundColor = Color.red;
        if (getcolor == "green")
            camera.backgroundColor = Color.green;
        if (getcolor == "blue")
            camera.backgroundColor = Color.blue;

    }

  

 
}