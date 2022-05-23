using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(CollisionMatrixCell))]
[CanEditMultipleObjects]
public class CollisionMatrixCellEditor : Editor {
	static string lastPath;
//	[SerializeField] byte delay = 20;

	public override void OnInspectorGUI(){
		if(targets.Length > 1){
			if(GUILayout.Button("SwitchAll"))
				foreach(Object obj in targets)
					try{
						CollisionMatrixCell cell = (CollisionMatrixCell)obj;
						cell.Switch();
					}catch{}
		}else{
			CollisionMatrixCell cell = (CollisionMatrixCell)target;
			if(GUILayout.Button("Switch"))
            	cell.Switch();
		}


		
		//if(cell.transform.parent != null)
			//if(cell.transform.GetComponent<CollisionMatrixUI>() != null)
			//	cell.Switch();
		
		DrawDefaultInspector();	
	}

/*	private void OnEnable(){
        if (!Application.isEditor){	Destroy(this);	}
        SceneView.duringSceneGui += OnScene;
    }
 
    void OnScene(SceneView scene){
        Event e = Event.current;
 
    	if (e.type == EventType.MouseDown && e.button == 1){
            Vector3 mousePos = e.mousePosition;
            float ppp = EditorGUIUtility.pixelsPerPoint;
            mousePos.y = scene.camera.pixelHeight - mousePos.y * ppp;
            mousePos.x *= ppp;
			
			Ray ray = scene.camera.ScreenPointToRay(mousePos);
            RaycastHit hit;
 
            if (Physics.Raycast(ray, out hit)){
                //Do something, ---Example---
                ((CollisionMatrixCell)target).Switch();
            }
            e.Use();
        }
    }
*/

}
