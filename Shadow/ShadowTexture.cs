using UnityEngine;
public class ShadowTexture : MonoBehaviour{
    SpriteRenderer sprite;
    void Awake(){
        sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate(){
        if(!Core.gameOn) return;
        if(World.pause) return;
        
        sprite.color = new Color(0, 0, 0, 0.25f*Core.game.world.sun.sun_power);
    }
}