using UnityEngine;
using UnityEngine.UI;
public class Console : MonoBehaviour{
    static InputField inputField;
    public static bool on;
    void Awake(){
        inputField = GetComponent<InputField>();
        Off();
    }

    public static void On(){
        on = true;
        inputField.enabled = on;
        inputField.gameObject.SetActive(on);
        inputField.Select();
    }

    public static void Off(){
        on = false;
        inputField.enabled = on;
        inputField.gameObject.SetActive(on);
    }

    public void ExecuteComand(){
        //int x=0,y=0;
        try{
            string [] keys = inputField.text.Split(' ');
            switch(keys[0]){
                case "Create":
                    /*
                    switch(keys[1]){      
                        case "Location":
                            Location location;
                            if(keys.Length == 3){
                                location = LocationManager.GetLocation(keys[2]);       
                            }else{
                                location = new Location(keys[2], int.Parse(keys[3]), int.Parse(keys[4]));
                            }
                            Core.CurrentLocation.Upload(location);
                        break;
                        case "Cell":
                            Cell.Type type = (Cell.Type) System.Enum.Parse(typeof(Cell.Type), keys[3]);
                            x = int.Parse(keys[4]);
                            y = int.Parse(keys[5]);
                            Core.CurrentLocation.location.cells[x][y] = CellManager.GetCell(keys[2],type,x,y);
                            Core.CurrentLocation.UploadCellVI(x,y);
                        break;
                        case "Creature":
                            Race race = (Race) System.Enum.Parse(typeof(Race), keys[3]);
                            x = int.Parse(keys[4]);
                            y = int.Parse(keys[5]);
                            Core.CurrentLocation.location.AddCreature(CreatureManager.GetCreature(keys[2],race,x,y));
                            Core.CurrentLocation.NewCreatureVI(Core.CurrentLocation.location.creatures[Core.CurrentLocation.location.cr-1]);
                        break;
                    }*/
                break;
                case "Destroy":/*
                    switch(keys[1]){
                        case "Cell":
                            if(keys.Length == 4){
                                x = int.Parse(keys[2]);
                                y = int.Parse(keys[3]);
                            }else{
                                x = GridVI.aX;
                                y = GridVI.aY;
                            }
                            Core.CurrentLocation.location.cells[x][y] = CellManager.GetCell(x,y);
                            Core.CurrentLocation.UploadCellVI(x,y);
                        break;
                        case "Creature":
                            x = GridVI.aX;
                            y = GridVI.aY;
                            Pos aim = new Pos(x,y);
                            int i = 0;
                            while( i<Core.CurrentLocation.location.cr &&  Core.CurrentLocation.location.creatures[i].pos != aim)
                                i++;
                            Debug.Log(Core.CurrentLocation.location.creatures[i].name);
                            Core.CurrentLocation.location.RemoveCreature(Core.CurrentLocation.location.creatures[i]);
                            Core.CurrentLocation.RemoveCreatureVI(i);
                        break;
                    }
                break;*/
                default:
                    Debug.Log("messed up comand, ask some scribe for clearance");
                break;
            }
        }catch{
            Debug.Log("error in execution, ask some scribe for clearance");
        }
    }
}
