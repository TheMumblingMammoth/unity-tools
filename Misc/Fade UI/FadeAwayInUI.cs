using UnityEngine;
using UnityEngine.UI;
public class FadeAwayInUI : MonoBehaviour{
    enum TargetType{ Character, Object}
    TargetType type;
    GameObject target;
    float time_to_fade;
    float time_in_fade;
    float fade_timer;

    bool fading_in, in_fade, fading_away;
    Image image;
    Color origin;
    public void Init(GameObject go, float ttf, float tif){
        type = TargetType.Object;
        target = go;
        time_to_fade = ttf;
        time_in_fade = tif;
        image = go.GetComponent<Image>();
        if(image == null)
            image = go.GetComponentInChildren<Image>();
        origin = image.color;
        FadeAwayStart();
    }
    
    void FixedUpdate(){
        if(fading_in) FadeIn();
        if(fading_away) FadeAway();
        if(in_fade) StayFade();
    }
    void FadeAwayStart(){
        fading_away = true;
        fading_in = false;
        in_fade = false;
        fade_timer = time_to_fade;
    }
    void FadeAway(){
        fade_timer -= Time.deltaTime;
        image.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
        if(fade_timer <= 0)
            StayFadeStart();
    }

    void StayFadeStart(){
        fading_away = false;
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
        fading_away = false;
        in_fade = false;
        fade_timer = 0;
    }
    void FadeIn(){
        fade_timer += Time.deltaTime;
        image.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
        if(fade_timer >= time_to_fade)
            Finish();
    }

    void Finish(){
        if(type.Equals(TargetType.Character)){
            target.GetComponent<Character>().busy = false;
        }
        image.color = origin;
        Destroy(gameObject, 0.1f);
    }
}