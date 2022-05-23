using UnityEngine;
public class CursorManager {
    static Texture2D def, attack, sit, item, talk, coin;
    static Texture2D l_storage, ul_storage, l_door, ul_door, sleep;
    public static void Initialize(){
        def = Resources.Load<Texture2D>("Sprites/Cursor/default");
        attack = Resources.Load<Texture2D>("Sprites/Cursor/attack");
        sit = Resources.Load<Texture2D>("Sprites/Cursor/sit");
        talk = Resources.Load<Texture2D>("Sprites/Cursor/talk");
        item = Resources.Load<Texture2D>("Sprites/Cursor/item");
        l_door = Resources.Load<Texture2D>("Sprites/Cursor/locked_door");
        ul_door = Resources.Load<Texture2D>("Sprites/Cursor/unlocked_door");
        l_storage = Resources.Load<Texture2D>("Sprites/Cursor/locked_storage");
        ul_storage = Resources.Load<Texture2D>("Sprites/Cursor/unlocked_storage");
        sleep = Resources.Load<Texture2D>("Sprites/Cursor/sleep");
        coin = Resources.Load<Texture2D>("Sprites/Cursor/coin");
        Choose(CursorPic.Default);
    }
    public static void Choose(CursorPic pic){
        switch(pic){
            case CursorPic.Default:     Cursor.SetCursor(def, new Vector2(0,0), CursorMode.Auto);       return;
            case CursorPic.Attack:      Cursor.SetCursor(attack, new Vector2(0,0), CursorMode.Auto);    return;
            case CursorPic.Sit:         Cursor.SetCursor(sit, new Vector2(0,0), CursorMode.Auto);       return;
            case CursorPic.Item:        Cursor.SetCursor(item, new Vector2(0,0), CursorMode.Auto);      return;
            case CursorPic.Talk:        Cursor.SetCursor(talk, new Vector2(0,0), CursorMode.Auto);      return;
            case CursorPic.Sleep:       Cursor.SetCursor(sleep, new Vector2(0,0), CursorMode.Auto);     return;
            case CursorPic.Coin:        Cursor.SetCursor(coin, new Vector2(0,0), CursorMode.Auto);      return;
            case CursorPic.Locked_Storage:      Cursor.SetCursor(l_storage, new Vector2(0,0), CursorMode.Auto);     return;
            case CursorPic.UnLocked_Storage:    Cursor.SetCursor(ul_storage, new Vector2(0,0), CursorMode.Auto);    return;
            case CursorPic.Locked_Door:         Cursor.SetCursor(l_door, new Vector2(0,0), CursorMode.Auto);        return;
            case CursorPic.UnLocked_Door:       Cursor.SetCursor(ul_door, new Vector2(0,0), CursorMode.Auto);       return;
        }
    }
}

public enum CursorPic{
    Default, Attack, Sit, Talk, Item,
    Locked_Storage, UnLocked_Storage, Locked_Door, UnLocked_Door, Sleep,
    Coin, 
}