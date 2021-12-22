using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
  [SerializeField]
    GameObject pause1;
    void Start()
    {
        pause1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
      //  if(this.CompareTag("Player") && other.CompareTag("Finish"))
      pause1.SetActive(true);
            Time.timeScale = 0;
           // SceneManager.LoadScene(0);
    }
    public void Menu(){
        SceneManager.LoadScene(0);
            Time.timeScale = 1;
    }
    public void Next(){
        SceneManager.LoadScene(3);
            Time.timeScale = 1;
    }
}
