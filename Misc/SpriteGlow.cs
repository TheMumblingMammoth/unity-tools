using UnityEngine;
public class SpriteGlow : MonoBehaviour{
    SpriteRenderer sprite;
    [SerializeField] bool rng;
    [SerializeField] bool pulsing;
    [SerializeField] Vector2 range;
    [SerializeField] float period;
    float alpha;
    bool dir;
    void Awake(){
        sprite = GetComponent<SpriteRenderer>();
        alpha = Random.Range(range.x, range.y);
    }

    void Update(){
        float delta = (rng? Random.Range(period, period * 2) : period) * (range.y - range.x);
        if(pulsing){
            alpha += delta*Time.deltaTime*(dir? 1 : -1);
            if(alpha > range.y) dir = !dir;
            if(alpha < range.x) dir = !dir;
        }else
            alpha += alpha + delta*Time.deltaTime*(Random.Range(0,100) > 50? 1 : -1);
        alpha = Mathf.Max(alpha, range.x);
        alpha = Mathf.Min(alpha, range.y);
        sprite.color = new Color(1f, 1f, 1f, alpha);
    }
}