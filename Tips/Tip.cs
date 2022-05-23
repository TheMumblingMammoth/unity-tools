using UnityEngine;
using UnityEngine.UI;
public class Tip : MonoBehaviour{
    [SerializeField] Text text;
    [SerializeField] Text button_text;
    void Start(){
        text.text = TextManager.UI_Record("Tip " + name);
        button_text.text = TextManager.UI_Record("Tip Button");
        Hide();
    }
    public void Show(){ gameObject.SetActive(true);     }
    public void Hide(){ gameObject.SetActive(false);    }
}