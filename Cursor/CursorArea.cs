using UnityEngine;
public class CursorArea : MonoBehaviour{
    [SerializeField] protected CursorPic pic;
    public void Set(CursorPic pic){    this.pic = pic; }
    void OnMouseExit(){ CursorManager.Choose(CursorPic.Default); }   

    void OnMouseEnter(){ CursorManager.Choose(pic); }

}