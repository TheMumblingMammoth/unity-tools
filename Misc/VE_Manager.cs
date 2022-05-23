using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class VE_Manager : MonoBehaviour{
    void Awake(){
        proxy = this;
        volume = Instantiate(Resources.Load<Volume>("Misc/Post Processing"));
        DontDestroyOnLoad(volume.gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public static VE_Manager proxy;
    static Volume volume;
    public static void Initialize(){
        if(proxy == null)   
            FindObjectOfType<VE_Manager>().Awake();
        SetGamma();
    }
    #region Fade
        public void FadeCharacter(Character character, float time_to_fade, float time_in_fade = 0){
            FadeAwayIn fade = Instantiate(Resources.Load<FadeAwayIn>("Misc/FadeAwayIn"));
            fade.Init(character, time_to_fade, time_in_fade);
        }

        public void FadeObject(GameObject obj, float time_to_fade, float time_in_fade){
            FadeAwayIn fade = Instantiate(Resources.Load<FadeAwayIn>("Misc/FadeAwayIn"));
            fade.Init(obj, time_to_fade, time_in_fade);
        }

        public void FadeObjectIn(GameObject obj, float time_to_fade, float time_in_fade = 0){
            FadeIn fade = Instantiate(Resources.Load<FadeIn>("Misc/FadeIn"));
            fade.Init(obj, time_to_fade, time_in_fade);
        }

        public void FadeObjectAway(GameObject obj, float time_to_fade, bool destroy = false){
            FadeAway fade = Instantiate(Resources.Load<FadeAway>("Misc/FadeAway"));
            fade.Init(obj, time_to_fade, destroy);
        }

        public void FadeUIIn(GameObject obj, float time_to_fade, float time_in_fade = 0){
            FadeInUI fade = Instantiate(Resources.Load<FadeInUI>("Misc/FadeInUI"));
            fade.Init(obj, time_to_fade, time_in_fade);
        }

        public void FadeUIAway(GameObject obj, float time_to_fade, bool destroy){
            FadeAwayUI fade = Instantiate(Resources.Load<FadeAwayUI>("Misc/FadeAwayUI"));
            fade.Init(obj, time_to_fade, destroy);
        }
    #endregion Fade
    #region  Post_proc
        public static void SetGamma(){
            ColorAdjustments ca;
            if(volume.profile.TryGet<ColorAdjustments>(out ca))
                ca.postExposure.value = Core.settings.gamma * (5f/100f) - 3f;
            volume.profile.Reset();
        }
        static float temp_timer;
        public static void SetTemp(float param){
            WhiteBalance wb;
            if(volume.profile.TryGet<WhiteBalance>(out wb))
                wb.temperature.value = param;
            volume.profile.Reset();
            temp_timer = 0;
        }
        static bool mist;
        public static void MistOn(bool on){
            Vignette vg;
            if(volume.profile.TryGet<Vignette>(out vg)){
                vg.intensity.value = on? 0.6f : 0.3f;
                vg.smoothness.value = on? 0.75f : 0.5f;
                vg.color = on ? new ColorParameter(Color.white) : new ColorParameter(Color.black) ;
            }
            volume.profile.Reset();
            mist = on;
        }
        
    #endregion  Post_proc

    #region Misc
        static float vg_transition_time;
        static float vg_transition_timer;
        static bool vg_transition_forward;
        public static void DarkBlink(float time){
            vg_transition_time = time;
            vg_transition_timer = 0;
            vg_transition_forward = true;
            Vignette vg;
            if(volume.profile.TryGet<Vignette>(out vg)){
                vg.color = new ColorParameter(Color.black);
            }
            volume.profile.Reset();
        }

        static void VignetteTransitionTock(){
            vg_transition_timer += Time.deltaTime * (vg_transition_forward?1:-1);
            if(vg_transition_timer >= vg_transition_time)
                vg_transition_forward = false;
            if(!vg_transition_forward && vg_transition_timer <= 0){
                vg_transition_time = 0;
                MistOn((Core.game.world.GetWeather().ToString().Contains("Fog") || Core.game.world.GetWeather().ToString().Contains("Mist")));
                return;
            }
            Vignette vg;
            if(volume.profile.TryGet<Vignette>(out vg)){
                vg.intensity.value = vg_transition_timer / vg_transition_time;
                vg.smoothness.value = vg_transition_timer / vg_transition_time;
            }
            volume.profile.Reset();
        }

    #endregion Misc


    void FixedUpdate(){
        if(!Core.gameOn) return;
        temp_timer++;
        if(temp_timer > 5) SetTemp(0);
        if(vg_transition_time != 0){
            
            VignetteTransitionTock();
            return;
        }
        if((Core.game.world.GetWeather().ToString().Contains("Fog") || Core.game.world.GetWeather().ToString().Contains("Mist")) != mist)
            MistOn(!mist);
        
    }
}