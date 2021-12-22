using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject lose;
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreText;
    public Transform Target;
    Vector3 startDistance, moveVec;

    void Start()
    {
        lose.SetActive(false);
        startDistance = transform.position - Target.position;
    }

    void Update()
    {
        
        moveVec = Target.position + startDistance;
        moveVec.z = 1.5f;
        moveVec.y = startDistance.y;
        transform.position = moveVec;
        scoreText.text = ((int)(player.position.x/2)+6).ToString();
    }
    public void Restart(){
        SceneManager.LoadScene(1);
        lose.SetActive(false);
            Time.timeScale = 1;
            
    }
    public void Menu(){
        SceneManager.LoadScene(0);
            Time.timeScale = 1;
    }
}
