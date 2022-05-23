using UnityEngine;
using UnityEngine.UI;
public class FadeInUI : MonoBehaviour{
    enum TargetType{ Character, Object}
    TargetType type;
    GameObject target;
    float time_to_fade;
    float time_in_fade;
    float fade_timer;

    bool fading_in, in_fade;
    Image image; Text text;
    Color origin;
    public void Init(GameObject go, float ttf, float tif){
        type = TargetType.Object;
        target = go;
        time_to_fade = ttf;
        time_in_fade = tif;
        image = go.GetComponent<Image>();
        if(image == null){
            text = go.GetComponent<Text>();
            origin = text.color;
        }else    origin = image.color;
        StayFadeStart();
    }
    
    void FixedUpdate(){
        if(fading_in) Fade_In();
        if(in_fade) StayFade();
    }
    
    void StayFadeStart(){
        if(image != null)   image.color = Color.clear;
        else    text.color = Color.clear;
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
        if(image != null)   image.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
        else    text.color = origin * new Vector4(1, 1, 1, fade_timer/time_to_fade);
        if(fade_timer >= time_to_fade)
            Finish();
    }

    void Finish(){
        if(type.Equals(TargetType.Character)){
            target.GetComponent<Character>().busy = false;
        }
        if(image != null)   image.color = origin;
        else text.color = origin;
        Destroy(gameObject, 0.1f);
    }
}