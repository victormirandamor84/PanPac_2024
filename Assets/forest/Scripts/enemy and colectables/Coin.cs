using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{
	
    [SerializeField] string TagPlayer="Jugador";
	
    [SerializeField] SphereCollider ColiderCoin;
    [SerializeField] GameObject thisCoin;
	[SerializeField] AudioClip _Coin;
    [SerializeField]int Points=10;    
    
    GameManager GameManager;
    AudioOptions _AudioOptions;


    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer){      
        GameManager.Points+=Points;
        GameManager.Coins--;
       thisCoin.SetActive(false);
       ColiderCoin.enabled=false;
       _AudioOptions.Sound(_Coin);
       }
    }  
    void Update() {
      SearchManagers();
    }
    void Awake(){
      SearchManagers();
      GameManager.Coins++;
    } 
    

    void SearchManagers() {
      
        if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
		if(_AudioOptions==null){
        _AudioOptions=FindObjectOfType<AudioOptions>();
        } 
      }   
    }
}	
