using UnityEngine;
public class FloatAround : MonoBehaviour{
    [SerializeField] float magX, magY;
    [SerializeField] float limX, limY;
    [SerializeField] int step;
    int timer = 0;
    private float sx,sy, x, y;
    void Start(){
        sx = transform.position.x;
        sy = transform.position.y;
    }
    void FixedUpdate(){
        timer++;
        if(timer != step)
            return;
        timer = 0;
        x += Random.Range(-magX, magX);
        y += Random.Range(-magY, magY);
        x = Mathf.Max(x, sx - limX);
        x = Mathf.Min(x, sx + limX);
        y = Mathf.Max(y, sy - limY);
        y = Mathf.Min(y, sy + limY);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}