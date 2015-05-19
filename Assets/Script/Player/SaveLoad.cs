using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad{

	public static void Save(int[] value){
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream fileStream = new FileStream (Application.persistentDataPath + "Save.go", FileMode.Create);
		binaryFormatter.Serialize (fileStream, value);
		fileStream.Close ();
		Debug.Log ("Saved");
	}

	public static int[] Load(){
		int[] value;
		if (File.Exists (Application.persistentDataPath + "Save.go")) {
			BinaryFormatter binaryFormatter = new BinaryFormatter ();
			FileStream fileStream = File.Open (Application.persistentDataPath + "Save.Go", FileMode.Open);
			value = (int[])binaryFormatter.Deserialize (fileStream);
			fileStream.Close ();
		} else {
			value = null;
		}
		Debug.Log ("Loaded");
		return value;

	}
}
