using UnityEngine;
using System.IO;
public class Loader {
	const float ppu = 8.0f;
	//public const string Path = @"D:\Projects\TauKita\export";
	public static Sprite LoadFromFront(string FileName, float PixelsPerUnit = ppu){
		return LoadNewSprite(@"\Sprites\Front\"+ FileName + ".png", PixelsPerUnit);
	}
	public static Sprite LoadFullPathSprite(string FilePath, float PixelsPerUnit = ppu) { 
		Sprite NewSprite;
		try{
			Texture2D SpriteTexture = LoadTexture(FilePath);
			NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0.5f,0f), PixelsPerUnit);
		}catch{
			Debug.Log("Cant find " + FilePath);
			NewSprite = null;
		}
		//
    	return NewSprite;
	}
    
	public static Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = ppu) { 
     // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
    	Sprite NewSprite;
		try{
			Texture2D SpriteTexture = LoadTexture(Application.dataPath + FilePath);
			NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0.5f,0f), PixelsPerUnit);
		}catch{
			Debug.Log("Cant find " + FilePath);
			NewSprite = null;
		}
		//
    	return NewSprite;
   }
	private static Texture2D LoadTexture(string FilePath){
		Texture2D Tex2D;
	
		
		byte[] FileData;
		if (File.Exists(FilePath)){
			FileData = File.ReadAllBytes(FilePath);
			Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
			Tex2D.filterMode = FilterMode.Point;
			if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
				return Tex2D;                 // If data = readable -> return texture
		}
		return null;                     // Return null if load failed
	}
}
