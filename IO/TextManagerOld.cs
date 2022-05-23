using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
public class TextManagerOld{
    public static string lang = "Ru";
    static List<Record> eventTexts;

    public static void Upload(string newLang){
        lang = newLang;
        eventTexts = new List<Record>(10);

        StreamReader reader = new StreamReader(Application.dataPath + @"\Texts\Events");
        
        string [] eventNames = TextManagerOld.RemoveSpecialCharacters(reader.ReadToEnd()).Split(';');

        foreach(string eventName in eventNames){
            reader = new StreamReader(Application.dataPath + @"\Texts\" +lang + @"\Events\" + eventName);
            eventTexts.Add(new Record(eventName,reader.ReadToEnd()));
        }

    }
    
    public static string EventText(string textName){
        foreach(Record record in eventTexts)
            if(record.name == textName)
                return record.text;

        return "";
    }

    static void Read(string fileName){

    }

    class Record{
        public string name;
        public string text;
        public  Record(string newName, string newText){
            name = newName;
            text = newText;
        }
    }
    public static string RemoveSpecialCharacters(string str) {
        StringBuilder sb = new StringBuilder();
        foreach (char c in str) {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ';' || c =='=' || c == ',') {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
    public static string LeaveOnlyNumbers(string str){
        StringBuilder sb = new StringBuilder();
        foreach (char c in str) {
            if (c >= '0' && c <= '9') {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}