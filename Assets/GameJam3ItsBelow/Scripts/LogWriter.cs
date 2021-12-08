using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LogWriter : MonoBehaviour
{
	// private string filePath;
	//
	// private void Start()
	// {
	// 	filePath = Application.persistentDataPath + "/logs.txt";
	// 	
	// 	if(File.Exists(filePath))
	// 	{
	// 		try
	// 		{
	// 			File.Delete(filePath);
	// 			Debug.Log("File deleted");
	// 		}
	// 		catch(Exception e)
	// 		{
	// 			Debug.LogError("NullReferenceException: Cannot delete the file! file may not exist!");
	// 			
	// 		}
	// 	}
	// }
	//
	// public void WriteFile(string message)
	// {
	// 	try
	// 	{
	// 		StreamWriter fileWriter = new StreamWriter(filePath, true);
	// 	
	// 		fileWriter.Write(message);
	// 		fileWriter.Close();
	// 	}
	// 	catch(Exception e)
	// 	{
	// 		Debug.LogError("cannot write into the file!");
	// 	}
	// }
	
}

public class LogWriter2 : MonoBehaviour
{
	// [MenuItem("Tools/Write file")]
	// static void WriteString()
	// {
	// 	string path = "Assets/Resources/test.txt";
	//
	// 	//Write some text to the test.txt file
	// 	StreamWriter writer = new StreamWriter(path, true);
	// 	writer.WriteLine("Test");
	// 	writer.Close();
	//
	// 	//Re-import the file to update the reference in the editor
	// 	AssetDatabase.ImportAsset(path); 
	// 	TextAsset asset = Resources.Load("test") as TextAsset;
	//
	// 	//Print the text from the file
	// 	Debug.Log(asset.text);
	// }
	//
	// [MenuItem("Tools/Read file")]
	// static void ReadString()
	//    {
	//        string path = "Assets/Resources/test.txt";
	//
	//        //Read the text from directly from the test.txt file
	//        StreamReader reader = new StreamReader(path); 
	//        Debug.Log(reader.ReadToEnd());
	//        reader.Close();
	//    }
}
