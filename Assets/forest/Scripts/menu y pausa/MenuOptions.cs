using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour {
	#region
	public Dropdown Quality, Resolution;
	//, Shadow, Vsync,Fullscreen;
	//public Toggle Fullscreen;
	//public bool Full;
	#endregion
	#region
	public void SetResolution (int Level){
		if(Level==0){
			Screen.SetResolution(848, 480, true);
		}
		if(Level==1){
			Screen.SetResolution(1024, 600, true);
		}
		if(Level==2){
			Screen.SetResolution(1280, 720, true);
		}
		if(Level==3){
			Screen.SetResolution(1920, 1080, true);
		}		 
	}	
	public void Set_antiAliasing(int Level){
		
		if(Level==0){
			QualitySettings.antiAliasing = 0;
			Debug.Log(QualitySettings.antiAliasing);

		}else if(Level==1){
			QualitySettings.antiAliasing = 2;
			Debug.Log(QualitySettings.antiAliasing);
		}else if(Level==2){
			QualitySettings.antiAliasing = 4;
			Debug.Log(QualitySettings.antiAliasing);
		}else if(Level==3){
			QualitySettings.antiAliasing = 8;
			Debug.Log(QualitySettings.antiAliasing);
		}
	}

	public void Get_Quality (int Level){
		
		if(Level==0){
			QualitySettings.SetQualityLevel(0,false);
		}else if(Level==1){
			QualitySettings.SetQualityLevel(1,true);
		}else if(Level==2){
			QualitySettings.SetQualityLevel(2,true);
		}else if(Level==3){
			QualitySettings.SetQualityLevel(3,true);
		}
	}

	public void ShadowsLevel(int Level){
		if(Level==0){
			QualitySettings.shadows = ShadowQuality.Disable;
			Debug.Log(QualitySettings.shadows);
		}else if(Level==1){
			QualitySettings.shadows = ShadowQuality.HardOnly;
			Debug.Log(QualitySettings.shadows);		
		}else if(Level==2){
			QualitySettings.shadows = ShadowQuality.All;
			Debug.Log(QualitySettings.shadows);
		}

	}
	public void fullScreen(int Level){
		if(Level==0){
			Screen.fullScreen = false;
			//Full=false;
		}else if(Level==1){
			Screen.fullScreen = true;
			//Full=true;
		}
	}
	public void GetVsync(int Vsync){
		if(Vsync==0){
			QualitySettings.vSyncCount = 0;
		Debug.Log(QualitySettings.vSyncCount);
		}else if(Vsync==1){
			QualitySettings.vSyncCount = 1;
			Debug.Log(QualitySettings.vSyncCount);		
		}else if(Vsync==2){
			QualitySettings.vSyncCount = 2;
			Debug.Log(QualitySettings.vSyncCount);
		}
	}
	#endregion
	#region
	public void scene(string name){ 
		SceneManager.LoadScene (name);
		}
	void OnDisable(){
		PlayerPrefs.SetInt ("SetQuality",Quality.value);
		PlayerPrefs.SetInt ("SetResolucion",Resolution.value);
		//PlayerPrefs.SetInt ("SetShadows",Shadow.value);		
		//PlayerPrefs.SetInt ("SetVsync",Vsync.value);
		//PlayerPrefs.SetInt ("SetFullScreen",Fullscreen.value);
	}	
	void Awake(){
		Quality.value=PlayerPrefs.GetInt ("SetQuality");
		Resolution.value=PlayerPrefs.GetInt ("SetResolucion");
		//Shadow.value=PlayerPrefs.GetInt ("SetShadows");
		//Vsync.value=PlayerPrefs.GetInt ("SetVsync");
		//Fullscreen.value=PlayerPrefs.GetInt ("SetFullScreen");
	}
		
	#endregion
}
