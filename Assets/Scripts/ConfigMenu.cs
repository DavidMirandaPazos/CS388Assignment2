using UnityEngine;
public class ConfigMenu : MonoBehaviour {
	public GameObject NOVRstuff; //single camera
	public GameObject VRStuff; //Two eyed camera
	public Fade fader;
	float testTime = 10f; //time to go back from vr
	// Use this for initialization
	void Start () {
		EndTest ();
	}
	//Load next scene when continue is pressed
	public void LoadNextScene(){
		this.enabled = false; //Security check to avoid multiple instances
							  //Load next scene (hardcoded)
		fader.FadeOut(2);
	}
	//Deactivates non vr camera, and activates vr
	public void StartTest(){
		NOVRstuff.SetActive (false);
		VRStuff.SetActive (true);
		Invoke ("EndTest", testTime);
	}
	//Deactivates vr camera and deactivates non vr
	public void EndTest(){
		VRStuff.SetActive (false);
		NOVRstuff.SetActive (true);
	}
}
