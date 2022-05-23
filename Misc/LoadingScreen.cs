using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class LoadingScreen : MonoBehaviour{
    public static LoadingScreen proxy; 
    
    //AnimatedImage image;

    public enum LoadingState{  World = 5, Areas = 30, Avatar = 60, Final = 100 }
    public static LoadingState state;
    [SerializeField] public Image bar;
    [SerializeField] Text text;
    void Awake(){
        proxy = this;
        bar.fillAmount = 0;
        //image = GetComponentInChildren<AnimatedImage>();
        gameObject.SetActive(false);
    }


    void Upload(){
        bar.fillAmount = (int)(state) * 0.01f ;
    }
    
    public void LoadScene(string sceneName){
        gameObject.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(string sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = true;
        while(operation.progress < 0.99f){
            proxy.bar.fillAmount = operation.progress;
            yield return null;
        }
    }

    public void LoadWorld(){
        gameObject.SetActive(true);
        loaded = false;
        state = LoadingState.World;
        bar.fillAmount = 0;
        text.text = TextManager.UI_Record("..Loading..");
    }
    public static bool loaded = true;
    void Update(){ 
        if((loaded || state == LoadingState.Final) && !manually) gameObject.SetActive(false);
        if(manually && !World.pause) Switch(false);
        Upload();
    }
    static bool manually;
    public static void Switch(bool on){
        manually = on;
        proxy.gameObject.SetActive(on);
    }
}