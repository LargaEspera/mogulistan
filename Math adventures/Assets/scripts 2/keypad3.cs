using UnityEngine;
using System.Collections;
 
public class keypad3 : MonoBehaviour {
 
    public string curPassword = "12345";
    public string input;
    public bool onTrigger;
    public bool doorOpen;
    public bool keypadScreen;
    public Transform doorHinge;

    public float Max_Z, Min_Z;
	public int VectorMove = 0;
	public float speed;
	private bool move;
 
    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }
 
    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }
 
    void Update()
    {
        Vector3 P = doorHinge.transform.position;
		P.z = P.z + speed * VectorMove * Time.deltaTime;
		if (move == true) {
			if(P.z <= Max_Z)
			{
				doorHinge.transform.position = P;
			}
		}
        if(input == curPassword)
        {
            doorOpen = true;
        }
        if(doorOpen)
        {
           // var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(-90.0f, 0, 0.0f), Time.deltaTime * 250);
           //doorHinge.transform.position = new Vector3(-48,9.5f,-32);
          //  float step = 3 * Time.deltaTime;
           // transform.position = Vector3.MoveTowards(transform.position, doorHinge.position, step);
           move = true;
        }
    }
    void Start()
    {
        
    }
    void OnGUI()
    {
        if(!doorOpen)
        {
            if(onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'R' to open keypad");
 
                if(Input.GetKeyDown(KeyCode.R))
                {
                    keypadScreen = true;
                    onTrigger = false;
                }
            }
 
            if(keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);
 
                if(GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    input = input + "1";
                }
 
                if(GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    input = input + "2";
                }
 
                if(GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    input = input + "3";
                }
 
                if(GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input = input + "4";
                }
 
                if(GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input = input + "5";
                }
 
                if(GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input = input + "6";
                }
 
                if(GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    input = input + "7";
                }
 
                if(GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    input = input + "8";
                }
 
                if(GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    input = input + "9";
                }
 
                if(GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input = input + "0";
                }
                if(GUI.Button(new Rect(5, 350, 100, 100), "Clear"))
                {
                    input = null;
                }
                if(GUI.Button(new Rect(215, 350, 100, 100), "Close"))
                {
                    keypadScreen = false;
                    onTrigger = true;
                }
            }
        }
    }
}