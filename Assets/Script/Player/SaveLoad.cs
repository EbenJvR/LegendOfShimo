using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad{

	public static void Save(float value){
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream fileStream = new FileStream (Application.persistentDataPath + "Save.go", FileMode.Create);
		binaryFormatter.Serialize (fileStream, value);
		fileStream.Close ();
		Debug.Log ("Saved" + value);
	}

	public static float Load(){
		float value;
		if (File.Exists (Application.persistentDataPath + "Save.go")) {
			BinaryFormatter binaryFormatter = new BinaryFormatter ();
			FileStream fileStream = File.Open (Application.persistentDataPath + "Save.Go", FileMode.Open);
			value = (float)binaryFormatter.Deserialize (fileStream);
			fileStream.Close ();
		} else {
			value = 0;
		}
		Debug.Log ("Loaded" + value);
		return value;

	}
}
