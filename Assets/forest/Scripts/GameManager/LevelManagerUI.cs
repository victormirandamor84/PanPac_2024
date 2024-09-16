using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManagerUI: MonoBehaviour{
#region    
	public string NextLevel, MainMenu="MainMenu";
	public float waitTime=3;
	
	[Header("Game Datos")]
    [SerializeField]int Life;
	[SerializeField]private int Heart,Score,Colectables;
    int lifeGameOver=0;
	
    [Header("textos")]
    [SerializeField]TextMeshProUGUI Points;
    [SerializeField]TextMeshProUGUI Lives,HeartText,ganastes;
     
	 [Header("Dependencias")]
     [SerializeField] GameManager gamanager;
#endregion    
#region Funtion Unity
    void Update(){
        Life=GameManager.lives;
        Score=GameManager.Points;
        Heart=GameManager.Hearts;
        Colectables=GameManager.Coins;
		
        Lives.text=Life.ToString();
        Points.text= Score.ToString();
        HeartText.text=Heart.ToString();
		
        LifeCoint();
		UpdateCoins();
    }
    void Start(){
        Life=GameManager.lives;
        Lives.text=Life.ToString();
        Points.text= Score.ToString();
        gamanager = FindObjectOfType<GameManager>();
        _Lives(GameManager.lives);
    }
#endregion
#region Funtion publics Creates
public void LifeCoint(){
        if(Life==lifeGameOver){
           // ManagerText.Perdiste();
       
        }else if(Life>=0){
         //StartCoroutine(NewBall(1.0f));   
        }
    }

    public void UpdateCoins(){
        if (Colectables==0){
            if(NextLevel!=MainMenu){
                ganastes.text="Siguiente Nivel";
            }            
            if(NextLevel==MainMenu){
                ganastes.text="Juego terminado";
            }
            Invoke ("ganaste" ,waitTime);
			gamanager.LoadLevel(NextLevel);
		}
    }
		public void _Lives(int _lives){
			ganastes.text="te quedan : " + _lives+ " vidas";
			Invoke ("ganaste" ,waitTime);
		}
		public void ganaste(){
			ganastes.text="";
		}
	public void NextBola(){
    ganastes.text="lives:"+GameManager.lives.ToString();
        ganastes.text=" ";
    }

}
#endregion