using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ProTex
{
[CustomEditor(typeof(ProTexMaterialBinder))]
public class ProTexMaterialBinderInspector : UnityEditor.Editor
{
	//------------------------------------------------------------------------------------------------------------------
	private enum TextureSize
	{
		TextureSize64x64 = 64,
		TextureSize128x128 = 128,
		TextureSize256x256 = 256,
		TextureSize512x512 = 512,
		TextureSize1024x1024 = 1024,
		TextureSize2048x2048 = 2048
	}
	
	//------------------------------------------------------------------------------------------------------------------
	private float progress;
	
	//------------------------------------------------------------------------------------------------------------------
	public override void OnInspectorGUI()
	{
		var proTexMaterialBinder = (ProTexMaterialBinder)target;

		DrawProTexTextureField(proTexMaterialBinder);
		DrawTextureSizeSelector(proTexMaterialBinder);
	}

	//------------------------------------------------------------------------------------------------------------------
	private void DrawProTexTextureField(ProTexMaterialBinder proTexMaterialBinder)
	{		
		if (Event.current.commandName == "ObjectSelectorUpdated")
		{
			var newProTexTexture = EditorGUIUtility.GetObjectPickerObject() as ProTexTexture;
			if (newProTexTexture != null)
			{
				SetProTexTexture(proTexMaterialBinder, newProTexTexture);
			}
		}
		else
		{
			var oldProTexTexture = proTexMaterialBinder.proTexTexture;
			var newProTexTexture = (ProTexTexture)EditorGUILayout.ObjectField(
				"ProTexTexture",
				oldProTexTexture,			
				typeof(ProTexTexture),
				false);

			if (newProTexTexture != oldProTexTexture)
			{
				SetProTexTexture(proTexMaterialBinder, newProTexTexture);
			}
		}
	}

	//------------------------------------------------------------------------------------------------------------------
	private void SetProTexTexture(ProTexMaterialBinder proTexMaterialBinder, ProTexTexture proTexTexture)
	{
		if ((proTexTexture == null) || (proTexTexture.GetVersionNumber() <= ProTexTexture.VersionNumber))
		{
			proTexMaterialBinder.proTexTexture = proTexTexture;
			proTexMaterialBinder.SetEditorPreviewTextures();
			EditorSceneManager.MarkSceneDirty(proTexMaterialBinder.gameObject.scene);
		}
		else
		{
			EditorUtility.DisplayDialog(
				"Invalid texture version",
				"The selected ProTexTexture version is newer than the current version",
				"OK");
		}				
	}
	
	//------------------------------------------------------------------------------------------------------------------
	private void DrawTextureSizeSelector(ProTexMaterialBinder proTexMaterialBinder)
	{
		TextureSize textureSize = GetTextureSize(proTexMaterialBinder);
		TextureSize newTextureSize = (TextureSize)EditorGUILayout.EnumPopup(textureSize);
		if (textureSize != newTextureSize)
		{
			proTexMaterialBinder.runtimeTextureSize = (int)newTextureSize;
		}
	}	

	//------------------------------------------------------------------------------------------------------------------
	private TextureSize GetTextureSize(ProTexMaterialBinder proTexMaterialBinder)
	{
		int textureSize = proTexMaterialBinder.runtimeTextureSize;
		foreach (var size in Enum.GetValues(typeof(TextureSize)))
		{
			if (Convert.ToInt32(size) >= textureSize)
			{
				return (TextureSize)size;
			}
		}

		return TextureSize.TextureSize256x256;
	}
}
}
