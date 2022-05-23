using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class SmartShadow : MonoBehaviour{
    SpriteRenderer host;
    SpriteMask shadow;
    [SerializeField] SpriteMask tall_shadow;
    [SerializeField] bool is_House;
    void Awake(){
        shadow = GetComponent<SpriteMask>();
        shadow.gameObject.layer = LayerMask.NameToLayer("Shadow");
        gameObject.SetActive(false);
        host = GetComponentInParent<SpriteRenderer>();
        gameObject.SetActive(true);
        if(!is_House) is_House = GetComponentInParent<OnFieldObject>() is OnFieldHouse;
        
        InShadow inShadow = Instantiate(Resources.Load<InShadow>("Worlds/FieldObjects/ShadowWorks/InShadow"));
        inShadow.Upload(host);
    }

    void FixedUpdate(){
        
        shadow.sprite = host.sprite;
        
        if(tall_shadow != null){
            tall_shadow.sprite = host.sprite;
            tall_shadow.frontSortingOrder = host.sortingOrder - 20;
            //tall_shadow.backSortingOrder = int.MinValue;
        }
        
        if(shadow.sortingLayerName == host.sortingLayerName)
            shadow.sortingOrder = host.sortingOrder-2;
        int d = Core.game.world.clock.GetTime().day;
        float t = (Core.game.world.clock.GetTime().InSeconds() - (new DataTime(d, 6, 0, 0)).InSeconds()) / (8f*60f*60f);
        if(Mathf.Abs(transform.position.z) < 10 && (t >= -0.01f  && t <= 2.01f)){
            shadow.enabled = true;
            tall_shadow.enabled = true;
            bool f = t < 1;
            t = Mathf.Abs(-1 + t);
            transform.localScale = new Vector3(1f + (is_House? 0 : 0.5f*t), 1 + t, 1);
            transform.localRotation = Quaternion.Euler(40 + 40*t, 40*t*(f?-1:1), 0);
        }else{
            shadow.enabled = false;
            tall_shadow.enabled = false;
            /*
            Light2D light = ClosestLight();
            if(light == null){
                shadow.enabled = false;
                return;
            }
            if(light.pointLightOuterRadius < Vector3.Distance(light.transform.position, transform.position)){
                shadow.enabled = false; return; 
            }
            shadow.enabled = true;
            shadow.color = new Color(0, 0, 0, 0.25f * light.intensity);
            */
        }
        transform.localScale = new Vector3((host.flipX? -1: 1) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    Light2D ClosestLight(){
        Light2D light = host.transform.parent.GetComponentInChildren<Light2D>();
        foreach(Light2D temp in host.transform.parent.GetComponentsInChildren<Light2D>())
            if(temp.enabled)
                if(Vector3.Distance(transform.position, temp.transform.position) < Vector3.Distance(transform.position, light.transform.position))
                    light = temp;
        if(light != null){
            if(light.enabled)
                return light;
            else 
                return null;
        }
        return null;
    }

}