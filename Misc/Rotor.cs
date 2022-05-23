using UnityEngine;
public class Rotor : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] float z = 0;
    void Update(){
        z += speed * Time.deltaTime % 360;
        transform.rotation = Quaternion.Euler(0, 0, z);
        
    }
}