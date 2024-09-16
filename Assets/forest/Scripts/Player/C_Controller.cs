using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Controller : MonoBehaviour{
    #region
    [SerializeField]bool CursorIsvisble;
    [Header ("Movement")]
    [SerializeField]float Speed;
    [SerializeField]string AxisHorizontal="Horizontal"
	,AxisVertical="Vertical",ButAtaque="Fire1"; 
    
    private  CharacterController _controller;
    private Vector3 moveDirection = Vector3.zero;
    private float Horizontal, Vertical;
	private Animator _anim;
    private Vector3 _move;
    private bool Attake;
	#endregion	
    #region
	void Awake(){
        _anim=GetComponent<Animator>();
        _controller=GetComponent<CharacterController>();
        }
		
    void Update(){
        Horizontal=Input.GetAxis(AxisHorizontal);
        Vertical=Input.GetAxis(AxisVertical);
        Attake=Input.GetButton(ButAtaque);
        _move=new Vector3(Vertical,0,Horizontal);
        Cursor.visible = CursorIsvisble;
        Atake();
        Rotate(_move);
        Movement(_move);       
    }
	#endregion
	#region
        void Movement(Vector3 Moverse){ 
        _controller.Move(Moverse * Time.deltaTime * Speed);
		_anim.SetFloat("SpeedX",Horizontal);
		_anim.SetFloat("SpeedY",Vertical);
        
     } 
		void Atake() {
        if (Attake==true){             
        _anim.SetBool("Ataque",true);
        }else{             
        _anim.SetBool("Ataque",false);
        }
    }
      void Rotate(Vector3 move){
        Vector3 Rotation=new Vector3 (move.x,0, move.z);        
         if (Horizontal!=0 || Vertical!=0){
          transform.rotation= Quaternion.LookRotation(Rotation);
        }
    }
	void moverse(){
		  if (Horizontal!=0){           
                 _anim.SetBool("IsRunning",true);             
        }if (Horizontal==0){                 
             _anim.SetBool("IsRunning",false);             
        }if (Vertical>=0.1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }if (Vertical==0){                 
             _anim.SetFloat("Speed",0.0f);             
        }if (Vertical<=-0.1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }
	}
    #endregion
}
