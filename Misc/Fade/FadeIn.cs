using UnityEngine;
public class FadeIn : MonoBehaviour{
    enum TargetType{ Character, Object}
    TargetType type;
    GameObject target;
    float time_to_fade;
    float time_in_fade;
    float fade_timer;

    bool fading_in, in_fade;
    SpriteRenderer sprite;
    Color origin;
    public void Init(GameObject go, float ttf, float tif){
        type = TargetType.Object;
        target = go;
        time_to_fade = ttf;
        time_in_fade = tif;
        sprite = go.GetComponent<SpriteRenderer>();
        if(sprite == null)
            sprite = go.GetComponentInChildren<SpriteRenderer>();
        origin = sprite.color;
        StayFadeStart();
    }
    
    public void Init(Character character, float ttf, float tif){
        type = TargetType.Character;
        target = character.gameObject;
        //character.busy = true;
        time_to_fade = ttf;
        time_in_fade = tif;
        sprite = character.sprite.GetComponent<SpriteRenderer>();
        origin = sprite.color;
        StayFadeStart();
    }

    void FixedUpdate(){
        if(fading_in) Fade_In();
        if(in_fade) StayFade();
    }
    
    void StayFadeStart(){
        sprite.enabled = true;
        sprite.color = Color.clear;
        fading_in = false;
        in_fade = true;
        fade_timer = 0;
    }
    void StayFade(){
        fade_timer += Time.deltaTime;
        if(fade_timer >= time_in_fade)
            FadeInStart();
    }        

    void FadeInStart(){
        fading_in = true;
        in_fade = false;
        fade_timer = 0;
    }
    void Fade_In(){
        fade_timer += Time.deltaTime;
        sprite.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
        if(fade_timer >= time_to_fade)
            Finish();
    }

    void Finish(){
        if(type.Equals(TargetType.Character)){
            //target.GetComponent<Character>().busy = false;
        }
        sprite.color = origin;
        Destroy(gameObject, 0.1f);
    }
}