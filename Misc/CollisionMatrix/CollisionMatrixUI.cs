using UnityEngine;
public class CollisionMatrixUI : MonoBehaviour{
    public CollisionMatrix owner;
    [SerializeField] CollisionMatrixCell [] cells;
    public void Upload(CollisionMatrix matrix){
        owner = matrix;
        transform.SetParent(owner.transform);
        transform.localPosition = new Vector3(0, 0, 0);
        cells = new CollisionMatrixCell[owner.size.x * owner.size.y];
        for(int i = 0; i < owner.size.y; i++)
            for(int j = 0; j < owner.size.x; j++){
                CollisionMatrixCell cell = Instantiate(Resources.Load<CollisionMatrixCell>("Misc/CollisionMatrix/CollisionMatrixCell"));
                cell.Upload(this, i, j);
                cell.transform.localPosition = new Vector3(0.5f + j - owner.size.x/2f, i, 0);
                cells[i * owner.size.x + j] = cell;
            }

        //SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        //owner.SetPixel
    }

    public void Upload(){
        for(int i = 0; i < owner.size.y; i++)
            for(int j = 0; j < owner.size.x; j++){
                if(owner.matrix[i][j])  cells[i * owner.size.x + j].sprite.color = new Color(0, 1, 0, 0.5f);
                else cells[i * owner.size.x + j].sprite.color = new Color(1, 0, 0, 0.5f);
            }
    }
}