using UnityEngine;
public class FadeAway : MonoBehaviour{
    enum TargetType{ Character, Object}
    TargetType type;
    GameObject target;
    float time_to_fade;
    float fade_timer;

    bool fading_away;
    SpriteRenderer sprite;
    Color origin;
    bool destroy;
    public void Init(GameObject go, float ttf, bool destroy){
        type = TargetType.Object;
        target = go;
        this.destroy = destroy;
        time_to_fade = ttf;
        sprite = go.GetComponentInChildren<SpriteRenderer>();
        origin = sprite.color;
        FadeAwayStart();
    }
    
    public void Init(Character character, float ttf, bool destroy){
        this.destroy = destroy;
        type = TargetType.Character;
        target = character.gameObject;
        //character.busy = true;
        time_to_fade = ttf;
        sprite = character.sprite.GetComponent<SpriteRenderer>();
        origin = sprite.color;
        FadeAwayStart();
    }

    void FixedUpdate(){
        if(fading_away) Fade_Away();
    }
    void FadeAwayStart(){
        fading_away = true;
        fade_timer = time_to_fade;
    }
    void Fade_Away(){
        fade_timer -= Time.deltaTime;
        sprite.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
        if(fade_timer <= 0)
            Finish();
            
    }

    
    void Finish(){
        sprite.color = origin;
        if(destroy)
            DestroyImmediate(target);
        else
            sprite.enabled = false;
        
        DestroyImmediate(gameObject);
    }
}