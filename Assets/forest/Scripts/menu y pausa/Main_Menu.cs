using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Main_Menu : MonoBehaviour{
	
	public GameObject Options, MainMenu;
	//public bool CursorIsVisible;

	private void Awake(){
		Cursor.visible =true;
		MainMenu.SetActive (true);
		Options.SetActive (false);
	}
	public void scene(string name){ 
	SceneManager.LoadScene (name);
	}

	public void options(bool options_Bool) {
		if(options_Bool==true){
			Options.SetActive (true);
			MainMenu.SetActive(false);
		}else{
			Options.SetActive (false);
			MainMenu.SetActive (true);
		}
	}
	public void Quit(){
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}



}
