using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Contains HUD components
public class HUD : MonoBehaviour {
	[SerializeField]
	Text text;
	[SerializeField]
	float elapsedTime = 0;
	bool isRunning = true;
	void Start () {
		text.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime +=Time.deltaTime;
		if(isRunning == true){
		text.text = elapsedTime.ToString();//Text.text is needed to access the string part.
		} 
	}
	public void StopGameTimer(){
		isRunning = false;
	}
}
