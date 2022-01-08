using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public float speed=20f;
    public float turnsmoothtime = 0.1f;
    public float gravity = -9.8f;
    float turnsmoothvelocity;
    public Transform cam;


    public Vector3 velocity;
    public float jumpheight=6f;
    public Transform groundcheck;
    public float grounddistance=0.4f;
    public LayerMask groundmask;
    bool isGrounded;
    
    void Update()
    {  
        MoveAction();
    
    }
    void FixedUpdate()
    {
        JumpAction();
    }
    void MoveAction(){
    
        float Hor =Input.GetAxisRaw("Horizontal");
        float Vert =Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Hor,0f,Vert).normalized;

        if( direction.magnitude >= 0.1f){

            float targetAngle=Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float Angle= Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnsmoothvelocity,turnsmoothtime);
            transform.rotation=Quaternion.Euler(0f,Angle,0f);

            Vector3 movDir =Quaternion.Euler(0f,targetAngle,0f)*Vector3.forward;
            controller.Move(movDir.normalized*speed*Time.deltaTime);
        }
    }

    void JumpAction(){
        isGrounded =Physics.CheckSphere(groundcheck.position,grounddistance,groundmask);

        if(isGrounded && velocity.y < 0){
            velocity.y =-2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded ){
                velocity.y= Mathf.Sqrt(jumpheight*-2f*gravity);
                anim.Play("Jump");
                anim.Play("Run");
            }
            
            velocity.y += gravity*Time.deltaTime;
            controller.Move(velocity*Time.deltaTime);
    }
    void RunAnimCorrect(){
        if(isGrounded){
            anim.SetBool("move",true);
            anim.SetInteger("run",1);
        }
        else if(!isGrounded)
        anim.SetInteger("run",0);
    }


}
