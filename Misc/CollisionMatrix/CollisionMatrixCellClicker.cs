using UnityEngine; 
#if UNITY_EDITOR
using UnityEditor;
[ExecuteInEditMode]
public class CollisionMatrixCellClicker : MonoBehaviour{
    [SerializeField] CollisionMatrixCell cell;
    private void OnEnable(){
        
        if (!Application.isEditor){	Destroy(this);	}
        SceneView.duringSceneGui += OnScene;
    }
    
    void OnScene(SceneView scene){

        

        //scene.
        //Debug.Log(scene.camera.ScreenToWorldPoint(Input.mousePosition));
        /*cell = GetComponent<CollisionMatrixCell>();
        
        Event e = Event.current;
        //e.
        
        if (e.type == EventType.MouseUp && e.button == 1){
            //Debug.Log(e.mousePosition);
            Debug.Log(scene.camera.ViewportToWorldPoint(e.mousePosition));
            //if (true){ GetComponent<CollisionMatrixCell>().Switch();   }
            e.Use();
        }
        */
    }
    void OnMouseDown(){
        Debug.Log(GetComponent<CollisionMatrixCell>().pos);
    }
}

#endif