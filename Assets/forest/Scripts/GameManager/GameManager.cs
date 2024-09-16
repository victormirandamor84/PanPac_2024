#region previous assignments
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion
#region GameStates
public enum GameState{
    inGame, pause, gameOver
}
#endregion

public class GameManager : MonoBehaviour{
    
#region Asignaciones previas
    public static GameManager gameManager;
    public static GameManager GM_Lives;
    public static int lives=10,Points=0, Coins=0,Hearts=100;
	public static int HighScore;
	
    [SerializeField] AudioOptions _AudioOptions;
    [SerializeField] GameObject Player, Player1,Player2;
    [SerializeField] Vector3 position;
    public float espera_Reespawn;
    [SerializeField]  string Tag_Seguir="player";

    
    public string NexLevel;
    public GameState currentGameState;
    [SerializeField]float volMusic, volSFX;

    [Header ("Sound Efects")]    
    public AudioClip Dead;
    public AudioClip Danger;
    

    private bool _IsCoin=false;
    public bool IsCoin{
        get=>_IsCoin;
        set=>_IsCoin=value;
        }
    
     
#endregion
#region Metodos Unity
    void Awake() {
         Singleton();
         SearchManagers();
    }
    void Update(){
        livesCount();
        HeartsCount();
        HealtScore();
        SearchManagers();        
    }

#endregion

#region metodos extras

  public void StartGame(){
        currentGameState=GameState.inGame;
        Time.timeScale = 1;
    }
    public void PauseGame(){
        currentGameState=GameState.pause;
        Time.timeScale = 0;
    }
    public void LoadLevel(string SceneToLoad){
        //currentGameState=GameState.gameOver;
        //Time.timeScale = 0;        
	   SceneManager.LoadScene (SceneToLoad);
       if(SceneToLoad=="MainMenu"){
           ResetGame();
		}
    }
    public void HealtScore(){
     if (Hearts >= 300){
         Hearts=100;
        lives++;        
        }
    }
    public void DeadMain() {
        ResetGame();
         SceneManager.LoadScene ("MainMenu");

    }


    public void ResetGame(){
        lives=8;
        Hearts=100;
        Points=0;
        Coins=0;     
        Time.timeScale =
        Time.timeScale == 0 ? 1: 0;
    }
    public void NextLive(){    
        Time.timeScale = 1;
         Player.transform.position=position;
         Player.SetActive(true);  
    }
    void livesCount(){
        if(lives==0){
            LoadLevel("MainMenu");
           
        }        
    }
    void HeartsCount(){
        if(Hearts<=0){
			Debug.Log("has muerto");
            _AudioOptions.Sound(Dead);
            Player.SetActive(false);            
            lives--;
            Hearts=100;           
			Time.timeScale = 0.5f;
            Invoke("NextLive", espera_Reespawn);
        }
    }
    
    public void PlayerChoise(int value) {
        if(value==1){
            Instantiate(Player1,position,Quaternion.identity);
        }
        if (value==2){
            Instantiate(Player2,position,Quaternion.identity);
    }
    }

    void SearchManagers() {
        if (Player == null){
            Player = GameObject.FindWithTag(Tag_Seguir);
		}if(_AudioOptions==null){
        _AudioOptions=FindObjectOfType<AudioOptions>();
        } 
    }
#endregion

#region singleton
        
    void Singleton(){
        if (gameManager!=null){
    Destroy(this);      
    }else{ 
        gameManager=this;
    DontDestroyOnLoad(this);
    }
}
#endregion    
}    

