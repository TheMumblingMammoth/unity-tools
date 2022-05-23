using UnityEngine;
using UnityEngine.UI;
public class FadeAwayUI : MonoBehaviour{
    enum TargetType{ Character, Object}
    TargetType type;
    GameObject target;
    float time_to_fade;
    float fade_timer;

    bool fading_away;
    Image image; Text text;
    Color origin;
    bool destroy;
    public void Init(GameObject go, float ttf, bool destroy){
        type = TargetType.Object;
        target = go;
        this.destroy = destroy;
        time_to_fade = ttf;
        image = go.GetComponent<Image>();
        if(image == null){
            text = go.GetComponent<Text>();
            origin = text.color;
        }else   origin = image.color;
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
        if(image != null)   image.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
        else    text.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
       
        if(fade_timer <= 0)
            Finish();
            
    }

    
    void Finish(){
        if(image != null){
            image.color = origin;
            if(destroy)
                DestroyImmediate(target);
            else
                image.enabled = false;
        }else{
            text.color = origin;
            if(destroy)
                DestroyImmediate(target);
            else
                text.enabled = false;
        }
        
        DestroyImmediate(gameObject);
    }
}