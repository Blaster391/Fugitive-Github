using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public float cameraMoveSpeed = 1f;
	public float cameraZoomSpeed = 0.5f;

	void FixedUpdate(){
		if(Input.GetAxis ("CameraVertical") != 0){
			transform.Translate (Vector3.up * Input.GetAxis ("CameraVertical") * cameraMoveSpeed);
		}
		if (Input.GetAxis ("CameraHorizontal") != 0) {
			transform.Translate (Vector3.right * Input.GetAxis ("CameraHorizontal") * cameraMoveSpeed);
		}
		if (Input.GetAxis ("CameraZoom") != 0) {
			transform.Translate (Vector3.forward * Input.GetAxis ("CameraZoom") * cameraZoomSpeed);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
