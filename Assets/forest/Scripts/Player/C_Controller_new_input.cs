using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class C_Controller_new_input : MonoBehaviour{
    
	Player_input playerInput;
	#region
    [SerializeField]bool CursorIsvisble;
	[Header ("Gravedad")]
	public float gravity = 20.0F;
    
    [Header ("Movement")]
    [SerializeField]float Speed;
    
    private Vector3 GravityDirection = Vector3.zero;
	private  CharacterController _controller;
    private Vector3 moveDirection = Vector3.zero;
	private Animator _anim;
    private Vector3 _move;
	#endregion	
    #region
	void OnEnable(){
		playerInput.Enable();
        }
	void OnDisable(){
		playerInput.Disable();
        }	
	
	void Awake(){
        _anim=GetComponent<Animator>();
		playerInput=new Player_input();
        _controller=GetComponent<CharacterController>();
        }
		
    void Update(){
		Vector2 VectorMove= playerInput.Player.move.ReadValue<Vector2>();
        Cursor.visible = CursorIsvisble;
        Rotate(VectorMove);
        Movement(VectorMove); 
		Gravity();	
    }
	#endregion
	#region
        void Movement(Vector2 Moverse){
			
		Vector3 _Movement= new Vector3(Moverse.x,0,Moverse.y);
        _controller.Move(_Movement * Time.deltaTime * Speed);
		_anim.SetFloat("SpeedX",Moverse.x);
		_anim.SetFloat("SpeedY",Moverse.y);
        
     } 
	 
	 void Gravity() {      
        GravityDirection.y -= gravity * Time.deltaTime;
        _controller.Move(GravityDirection * Time.deltaTime);
    }
      void Rotate(Vector2 Moverse){
        Vector3 Rotation=new Vector3 (Moverse.x,0, Moverse.y);        
         if (Moverse.x!=0 || Moverse.y!=0){
          transform.rotation= Quaternion.LookRotation(Rotation);
        }
    }
    #endregion
}
