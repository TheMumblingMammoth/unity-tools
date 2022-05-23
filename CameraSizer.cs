using UnityEngine;
public class CameraSizer : MonoBehaviour{
    Camera cmr;
    public static CameraSizer proxy;
    public const float min = 3, max = 6;
    [SerializeField] float speed;
    SimpleFollow follow;
    float size;
    void Awake(){
        cmr = GetComponent<Camera>();
        size = cmr.orthographicSize;
        follow = GetComponent<SimpleFollow>();
        proxy = this;
    }
    public static bool demi_big {/*private*/ get; set;}
    void Update(){
        if(!Core.gameOn) return;
        bool half = Core.player.talking || Core.player.avatar.dancing;
        
        if(Core.player.avatar.z == 0){
            if(!JornalUI.proxy.gameObject.activeInHierarchy && !SkillTreeUI.proxy.gameObject.activeInHierarchy )
                size -= Input.mouseScrollDelta.y;
            size = Mathf.Max(size, min);
            size = Mathf.Min(size, half ? (max - (max - min)/2) : max);
            if(cmr.orthographicSize>size)   cmr.orthographicSize = Mathf.Max(size, cmr.orthographicSize - speed * Time.deltaTime);
            if(cmr.orthographicSize<size)   cmr.orthographicSize = Mathf.Min(size, cmr.orthographicSize + speed * Time.deltaTime);
        }else{
            float min_m = demi_big ? min + (max - min) / 2 : min;
            if(demi_big){
                if(!JornalUI.proxy.gameObject.activeInHierarchy && !SkillTreeUI.proxy.gameObject.activeInHierarchy )
                    size -= Input.mouseScrollDelta.y;
                size = Mathf.Max(size, min);
                size = Mathf.Min(size, half ? (max - (max - min)/2) : max);
            }
            if(cmr.orthographicSize>min_m)   cmr.orthographicSize = Mathf.Max(min_m, cmr.orthographicSize - speed * Time.deltaTime);
            if(cmr.orthographicSize<min_m)   cmr.orthographicSize = Mathf.Min(min_m, cmr.orthographicSize + speed * Time.deltaTime);
        }
    }

    public static float SizeKoef(){
        return Mathf.Pow(proxy.size/min, 1f);
    }
}