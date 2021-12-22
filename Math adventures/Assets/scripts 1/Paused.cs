using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    private AudioSource audio1;
    private float volume = 0.3f;
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        pause.SetActive(false);
    }

   
    void Update()
    {
        audio1.volume = volume;
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void SetVolume(float vol){
        volume = vol;
    }
    public void PauseOff(){
        pause.SetActive(false);
            Time.timeScale = 1;
    }
    public void PauseOff1(){
        SceneManager.LoadScene(3);
            Time.timeScale = 1;
    }
    public void Menu(){
        SceneManager.LoadScene(0);
            Time.timeScale = 1;
    }
}
