using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(CollisionMatrix))]
public class CollisionMatrixEditor : Editor {
	static string lastPath;
	public override void OnInspectorGUI(){
		CollisionMatrix matrix = (CollisionMatrix)target;
		/*if(GUILayout.Button("LoadFromFolder")){
			string path;
			if(lastPath == null)
				path = EditorUtility.OpenFolderPanel("Choose Folder",Application.dataPath+"/Sprites","");	
			else
				path = EditorUtility.OpenFolderPanel("Choose Folder", lastPath ,""); 
			if(path != null)
				if(path != ""){
					clip.LoadFrames(FrameImporter.ImportSprites(path));
					clip.name = path.Split('/')[path.Split('/').Length - 1];
					lastPath = path.Remove(path.Length - clip.name.Length);
				}
					
		}*/
		if(GUILayout.Button("Visualize")){
            matrix.visualise = !matrix.visualise;
            matrix.UploadUI();
        }
		DrawDefaultInspector();	
		/*if(matrix.visualise){
            Debug.Log("Ssss");
            matrix.UploadUI();
        }*/

		if (GUI.changed){
            EditorUtility.SetDirty(matrix);
            EditorSceneManager.MarkSceneDirty(matrix.gameObject.scene);
        }
	}

}
