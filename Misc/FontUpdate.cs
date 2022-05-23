using UnityEngine;
using UnityEngine.UI;
public class FontUpdate : MonoBehaviour{

    [SerializeField] Font font;
    [ContextMenu("ss")]
    public void UploadFont(){
        var textComponents = Component.FindObjectsOfType<Text>();
        foreach(var component in textComponents)
            component.font = font;
    }
}