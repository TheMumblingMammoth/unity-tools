using UnityEngine;
public class SunSensetveSprite : MonoBehaviour{
    SpriteRenderer sprite;
    [SerializeField] Vector2 sun_range;
    [SerializeField] Vector2 alpha_range;
    [SerializeField] bool reverse;
    void Awake(){
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update(){
        try{
            float alpha = Core.game.world.sun.sun_power;
            alpha =  alpha_range.x + ((alpha - sun_range.x)/(sun_range.y - sun_range.x)) * (alpha_range.y - alpha_range.x);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, reverse? 1 - alpha : alpha);
        }catch(System.Exception e){
            Debug.Log("Sun not found " +e.ToString());
            return;
        }
        
    }
}