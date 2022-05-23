using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class SunSensetveLight : MonoBehaviour{
    Light2D light2D;
    [SerializeField] Vector2 sun_range;
    [SerializeField] Vector2 alpha_range;
    [SerializeField] bool reverse;
    void Awake(){
        light2D = GetComponent<Light2D>();
    }

    void Update(){
        try{
            float alpha = Core.game.world.sun.sun_power;
            alpha =  alpha_range.x + ((alpha - sun_range.x)/(sun_range.y - sun_range.x)) * (alpha_range.y - alpha_range.x);
            light2D.intensity = reverse? alpha_range.y - alpha: alpha;
        }catch(System.Exception e){
            Debug.Log("Sun not found " +e.ToString());
            return;
        }
        
    }
}