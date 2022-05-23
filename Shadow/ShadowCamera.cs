using UnityEngine;
public class ShadowCamera : MonoBehaviour{
    Camera shadow_camera;
    void Awake(){
        shadow_camera = GetComponent<Camera>();
    }
    void FixedUpdate(){
        shadow_camera.orthographicSize = 9;//Camera.main.orthographicSize;
    }
}