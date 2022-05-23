using UnityEngine;
public class TipsManager : MonoBehaviour{
    static TipsManager proxy;
    Tip [] tips;
    void Awake(){
        proxy = this;
        tips = GetComponentsInChildren<Tip>();
        DontDestroyOnLoad(gameObject);
    }

    public static void Show(string tip_name){
        if(Core.ActiveProfile() == null || proxy == null) return;
        if(Core.ActiveProfile().ShowTip(tip_name))
            foreach(Tip tip in proxy.tips)
                if(tip.name.Equals(tip_name))
                    tip.Show();
    }
}