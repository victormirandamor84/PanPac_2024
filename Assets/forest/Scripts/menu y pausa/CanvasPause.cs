#region Previas
using UnityEngine; 
using System.Collections; 
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
#endregion
public class CanvasPause : MonoBehaviour {
    
	public Canvas canvasPausa;
	public string CancelButton="Cancel";
	
	void Start(){
	canvasPausa.enabled = false;
	Time.timeScale = 1;
	}
	public void Pause(){
		
		canvasPausa.enabled = !canvasPausa.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
		}

	void Update(){

		if (Input.GetButtonDown (CancelButton)){
			Pause();
			}
		if(Time.timeScale==0){
            Debug.Log("pause");
             }
	}
	public void CursorTrue(){
		Cursor.visible = true; 
	}
	public void CursorFalse(){
		Cursor.visible = false; 
	}
}