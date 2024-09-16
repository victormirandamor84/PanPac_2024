using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEnemy : MonoBehaviour{
    
	[Header("Player")]
	[SerializeField] string TagPlayer="Jugador";
	[Header("Colision")]
    [SerializeField] Collider capsuleCollider;
    [SerializeField]Color Verde, Rojo;
	[SerializeField] Material EnemyMat;
	[Header("Cambio")]
    [SerializeField] float waitTime;
    [SerializeField]int _Sound;
    [SerializeField] AudioClip _EnemyChange;
    [SerializeField]Text TextCargar;
    
    GameManager GameManager;

    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer){
        //FXManager.SoundPlay(_EnemyChange,_Sound);        
        GameManager.IsCoin=true;
        capsuleCollider.isTrigger=false;
        EnemyMat.color=Rojo;
        StartCoroutine(VidaEnemy());
        }
    }  
    
    void SearchManagers() {      
           if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
      }   
    }
     void Awake(){
        SearchManagers();
        EnemyMat.color=Verde;

        }    
      IEnumerator VidaEnemy(){
        TextCargar.text="Tu turno de atacar!";
      yield return new WaitForSeconds(waitTime);
      TextCargar.text="";
      GameManager.IsCoin=false;
      capsuleCollider.enabled=false;
      Debug.Log("tiempo acabado");
	 }

}
