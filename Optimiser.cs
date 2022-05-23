using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Optimiser : MonoBehaviour{
    bool active;
    void Start(){
        active = true;
        Switch();
    }
    void FixedUpdate(){
        if(active != Vector2.Distance(transform.position, Camera.main.transform.position) < Camera.main.orthographicSize*6)
            Switch();
    }
    void Switch(){
        active = !active;
        foreach(SmartShadow shadow in GetComponentsInChildren<SmartShadow>())
            shadow.enabled = active;
        foreach(InShadow in_shadow in GetComponentsInChildren<InShadow>())
            in_shadow.enabled = active;
        foreach(RotorShadow rotor_shadow in GetComponentsInChildren<RotorShadow>())
            rotor_shadow.enabled = active;
        foreach(SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
            spriteRenderer.enabled = active;
        foreach(AnimatedSprite animatedSprite in GetComponentsInChildren<AnimatedSprite>())
            animatedSprite.enabled = active;
    }
}
