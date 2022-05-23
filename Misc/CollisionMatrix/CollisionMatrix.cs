using UnityEngine;
public class CollisionMatrix : MonoBehaviour{
    public bool visualise;
    public Vector2Int size;
    [SerializeField] string encode_matrix;
    public bool [] [] matrix {get; set;}

    void Awake(){
        if(GetComponentInChildren<CollisionMatrixUI>() != null)
            DestroyImmediate(GetComponentInChildren<CollisionMatrixUI>().gameObject);
        Decode();
    }


    [ContextMenu("UploadUI")]
    public void UploadUI(){
        Decode();
        if(!visualise){
            if(GetComponentInChildren<CollisionMatrixUI>() != null){
                Encode();
                DestroyImmediate(GetComponentInChildren<CollisionMatrixUI>().gameObject);
            }
            return;
        }
        CollisionMatrixUI collisionMatrixUI = GetComponentInChildren<CollisionMatrixUI>();
        if(collisionMatrixUI == null){
            collisionMatrixUI = Instantiate(Resources.Load<CollisionMatrixUI>("Misc/CollisionMatrix/CollisionMatrixUI"));
            collisionMatrixUI.Upload(this);
        }
        collisionMatrixUI.Upload();

    }

    public void Encode(){
        encode_matrix = "";
        for(int i = 0; i < size.y; i++)
            for(int j = 0; j < size.x; j++)
                encode_matrix += matrix[i][j]?"0":"1";
    }

    public void Decode(){
        if(matrix == null || matrix.Length != size.y || matrix[0].Length != size.x){
            matrix = new bool[size.y][];
            for(int i = 0; i < size.y; i++) matrix[i] = new bool[size.x];
            
        }
        if(encode_matrix.Length != size.y*size.x) encode_matrix = "";

        if(encode_matrix == "") return;
        char [] ch_array = encode_matrix.ToCharArray();
        for(int i = 0; i < size.y; i++)
            for(int j = 0; j < size.x; j++)
                matrix[i][j] = ch_array[i * size.x + j] == '0';
    }
}