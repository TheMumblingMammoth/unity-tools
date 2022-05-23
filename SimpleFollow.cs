using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 dist;
    
    // Update is called once per frame
    public void SetAim(GameObject target){
        this.target = target;
    }   

    void Update()
    {
        if(target != null)
            transform.position = new Vector3(target.transform.position.x - dist.x, target.transform.position.y  - dist.y, target.transform.position.z  - dist.z);
    }
}
