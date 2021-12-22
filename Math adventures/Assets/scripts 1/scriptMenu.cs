using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class scriptMenu : MonoBehaviour
{
    [SerializeField]
    GameObject helped;
    public string sceneName;
    public Button playRunner;
    public Button play2;
    public Button help;
    public Button back;
    public Button Exit;
    private AudioSource audio1;
    private float volume = 0.5f;  
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        helped.SetActive(false);
        playRunner.onClick.AddListener(TaskOnClick);
        Exit.onClick.AddListener(TaskOnClick1);
        play2.onClick.AddListener(TaskOnClick2);
        help.onClick.AddListener(TaskOnClick3);
        back.onClick.AddListener(TaskOnClick4);
    }
    void TaskOnClick2(){
        SceneManager.LoadScene(2);
    }
    void TaskOnClick(){
        SceneManager.LoadScene(sceneName);
    }
    void TaskOnClick1(){
        Application.Quit();
    }
    void TaskOnClick3(){
        helped.SetActive(true);
    }
    void TaskOnClick4(){
        helped.SetActive(false);
    }   
    void Update()
    {
        audio1.volume = volume;
    }
    public void SetVolume(float vol){
        volume = vol;
    }
}
