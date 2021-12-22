using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject lose;
    CharacterController cc;
    Vector3 moveVec, gravity;
    public float speed = 5, jumpSpeed = 12;
    int laneNumber = 1, lanesCount = 2;
    public float FirstLanePos, LaneDistance, SideSpeed; 
    bool isRolling = false;
    Vector3 ccCenterNorm = new Vector3(0,1,0), ccCenterRoll = new Vector3(0, 0.5f, 0);
    float ccHeightNorm = 2, ccHeightRoll = 1;
    Animator roller;
    void Start()
    {
        lose.SetActive(false);
        cc = GetComponent<CharacterController>();
        moveVec = new Vector3(1,0,0);
        gravity = Vector3.zero;
        roller = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            speed = 20;
            SideSpeed = 10;
        }
        if(Input.GetKeyDown(KeyCode.Y)){
            speed = 5;
            SideSpeed = 5;
        }
        if (cc.isGrounded){
            gravity = Vector3.zero;
            
          // if(!isRolling){

            if (Input.GetAxisRaw("Vertical") > 0){
                gravity.y = jumpSpeed;
                StartCoroutine(DoJump());
            }
           else if (Input.GetAxisRaw("Vertical") < 0){
                StartCoroutine(DoRoll());
            }
           // }

        }
        else gravity += Physics.gravity * Time.deltaTime * 3.5f;
        moveVec.x = speed;
        moveVec += gravity;
        moveVec *= Time.deltaTime;
      
        CheckInput();
        cc.Move(moveVec);
        Vector3 newPos = transform.position;
        newPos.z = Mathf.Lerp(newPos.z, FirstLanePos + (laneNumber * LaneDistance), Time.deltaTime * SideSpeed);
        transform.position = newPos;

    }
    void CheckInput(){
        int sign = 0;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            sign = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            sign = 1;
        }
        else return;

        laneNumber += sign;
                laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "obstacle"){
            lose.SetActive(true);
            Time.timeScale = 0;
        }
    }
  IEnumerator DoRoll(){
        isRolling = true;
        roller.SetBool("isRolling",true);
        cc.center = ccCenterRoll;
        cc.height = ccHeightRoll;
        yield return new WaitForSeconds(1);
        roller.SetBool("isRolling",false);
        isRolling = false;
        cc.center = ccCenterNorm;
        cc.height = ccHeightNorm;
  }
  IEnumerator DoJump(){
        roller.SetBool("isJumping",true);
        yield return new WaitForSeconds(0.5f);
        roller.SetBool("isJumping",false);
  }
}
