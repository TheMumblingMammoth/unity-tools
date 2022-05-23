using UnityEngine;
public class CollisionMatrixCell : MonoBehaviour{
    [SerializeField] CollisionMatrixUI owner;
    public SpriteRenderer sprite;
    public Vector2Int pos {get; private set;}
    public void Upload(CollisionMatrixUI matrix, int i , int j){
        owner = matrix;
        transform.SetParent(owner.transform);
        transform.localPosition = new Vector3(0, 0, 0);
        pos = new Vector2Int(i, j);
        if(owner.owner.matrix[i][j])  sprite.color = new Color(0, 1, 0, 0.5f);
        else sprite.color = new Color(1, 0, 0, 0.5f);
        //SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        //owner.SetPixel
    }

    [ContextMenu("Switch")]
    public void Switch(){
        if(owner.owner.matrix == null) owner.owner.Decode();
        owner.owner.matrix[pos.x][pos.y] = !owner.owner.matrix[pos.x][pos.y];
        if(owner.owner.matrix[pos.x][pos.y])  sprite.color = new Color(0, 1, 0, 0.5f);
        else sprite.color = new Color(1, 0, 0, 0.5f);
        owner.owner.Encode();
    }

}