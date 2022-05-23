using UnityEngine;

[System.Serializable] public class NamedSprite{
    public string name;
    public Sprite sprite;
    public NamedSprite(Sprite newSprite, string newName){
        sprite = newSprite;
        name = newName;
    }
}