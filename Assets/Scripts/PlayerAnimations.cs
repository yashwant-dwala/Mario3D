using System.Collections.Generic;
using UnityEngine;
// using static ThirdPersonMovement;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;

    private bool move,roll,jump;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.W)) {
            move =true;
            // anim.SetBool("move",true);
        } if(Input.GetKeyDown(KeyCode.A)) {
            move =true;
            // anim.SetBool("move",true);
        } if(Input.GetKeyDown(KeyCode.S)) {
            move =true;
            // anim.SetBool("move",true);
        } if(Input.GetKeyDown(KeyCode.D)) {
            move =true;
            // anim.SetBool("move",true);
        }
        if(Input.GetButtonDown("LShift")) roll=true;
        if(Input.GetButtonDown("Jump")) jump=true;
        MoveAndRoll();
        Jump();
        Kick();
        Fire();
        ExitAnimations();
    }

    void MoveAndRoll(){
        if( move ){
            anim.SetInteger("run",1);
            if(roll){
                move = false;
                anim.SetInteger("run",0);
                anim.SetInteger("roll",3);
            }
            else if(jump){
                move = false;
                anim.SetInteger("run",0);
                anim.SetInteger("jump",2);
                move = true;
            }
        }
        else if(roll){
            anim.SetInteger("roll",3);
            if(jump){
                move = false;
                anim.SetInteger("run",0);
                anim.SetInteger("roll",0);
                anim.SetInteger("jump",-23);
            }
            else if(move){
                anim.SetInteger("run",1);
            }
        }
            
        
    }
    void Kick(){
        if(Input.GetMouseButton(0)){
            anim.SetInteger("kick",4);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump"))
            anim.SetInteger("jump",2);
    }

    void Fire(){
        if(Input.GetMouseButton(1)){
            anim.SetInteger("fire",5);
        }
    }


    void ExitAnimations(){

        // if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)){
        //     move = false;
        //     anim.SetBool("move",false);
        //     anim.SetInteger("run",0);
        // } 
        if(Input.GetKeyUp(KeyCode.W)) {
            move = false;
            // anim.SetBool("move",false);
            anim.SetInteger("run",-1);
        } if(Input.GetKeyUp(KeyCode.A)) {
            move = false;
            // anim.SetBool("move",false);
            anim.SetInteger("run",-1);
        } if(Input.GetKeyUp(KeyCode.S)) {
            move = false;
            // anim.SetBool("move",false);
            anim.SetInteger("run",-1);
        } if(Input.GetKeyUp(KeyCode.D)) {
            move = false;
            // anim.SetBool("move",false);
            anim.SetInteger("run",-1);
        }
        else if(Input.GetKeyUp(KeyCode.Space)){
            jump = false;
            anim.SetInteger("jump" ,-2);
        }
        else if(Input.GetButtonUp("LShift")){
            roll = false;
            anim.SetInteger("roll" ,-3);
            // speed -=5f;
        }
        else if(Input.GetMouseButtonUp(0)){
            anim.SetInteger("kick" ,0);
        }
        else if(Input.GetMouseButtonUp(1)){
            anim.SetInteger("fire" ,0);
        }
    }


}
