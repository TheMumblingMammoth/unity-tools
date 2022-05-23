using UnityEngine;
public class InShadow : MonoBehaviour{
    SpriteRenderer sprite, host;
    [SerializeField] bool manual;
    void Awake(){
        if(manual)    Upload(transform.parent.GetComponent<SpriteRenderer>());
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update(){
        sprite.sprite = host.sprite;
        sprite.sortingOrder = host.sortingOrder + 20;
        transform.localScale = new Vector3(host.flipX? -1 : 1, 1, 1);
        sprite.color = new Color(0, 0, 0, 0.25f*Core.game.world.sun.sun_power); 
    }
    public void Upload(SpriteRenderer host){
        this.host = host;
        transform.parent = host.transform;
        transform.localPosition = new Vector3(0, 0, 0);
    }
}