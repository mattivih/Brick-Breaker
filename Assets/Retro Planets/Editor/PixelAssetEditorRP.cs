using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PixelAssetRP), true)]
public class PixelAssetEditorRP : Editor {

	public override void OnInspectorGUI(){
		PixelAssetRP gen = (PixelAssetRP)target;

		DrawDefaultInspector();

		ShowGenerationButtons(gen);
	}

	protected void ShowGenerationButtons(PixelAssetRP gen){

		if(GUILayout.Button("Generate Sprite")){
			gen.GenerateAsset();
		}

	}
}
