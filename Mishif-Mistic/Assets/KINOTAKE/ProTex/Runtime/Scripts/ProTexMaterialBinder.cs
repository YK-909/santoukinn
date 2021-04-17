using UnityEngine;

namespace ProTex
{
public class ProTexMaterialBinder : MonoBehaviour
{
	//------------------------------------------------------------------------------------------------------------------
	public ProTexTexture proTexTexture;
	public int runtimeTextureSize = 256;
	
	//------------------------------------------------------------------------------------------------------------------
	private const int EditorPreviewTextureSize = 16;
	
	//------------------------------------------------------------------------------------------------------------------
	void Start()
	{
		if (proTexTexture != null)
		{
			var meshRenderer = gameObject.GetComponent<MeshRenderer>();
			var material = (meshRenderer != null) ? meshRenderer.material : null;
			if (material != null)
			{
				UpdateMaterial(material, runtimeTextureSize);
			}
			else
			{
				Debug.LogError("No material detected. GameObject [" + gameObject.name + "]");
			}
		}
	}

	//------------------------------------------------------------------------------------------------------------------
	public void SetEditorPreviewTextures()
	{
		if (proTexTexture != null)
		{
			var meshRenderer = gameObject.GetComponent<MeshRenderer>();
			if ((meshRenderer == null) || (meshRenderer.sharedMaterial == null))
			{
				Debug.LogError("No material detected. GameObject [" + gameObject.name + "]");
			}
			else
			{
				var material = new Material(meshRenderer.sharedMaterial);
				meshRenderer.sharedMaterial = material;

				UpdateMaterial(material, EditorPreviewTextureSize);
			}
		}
	}
	
	//------------------------------------------------------------------------------------------------------------------
	private bool IsDefaultMaterial(Material material)
	{
		return
			material.HasProperty("_MainTex") &&
			material.HasProperty("_BumpMap") &&
			material.HasProperty("_ParallaxMap") &&
			material.HasProperty("_MetallicGlossMap") &&
			material.HasProperty("_OcclusionMap") &&
			material.HasProperty("_EmissionMap");
	}

	//------------------------------------------------------------------------------------------------------------------
	private bool IsHighDefinitionRenderPipelineMaterial(Material material)
	{
		return
			material.HasProperty("_BaseColorMap") &&
			material.HasProperty("_NormalMap") &&
			material.HasProperty("_HeightMap") &&
			material.HasProperty("_MaskMap") &&
			material.HasProperty("_EmissiveColorMap");
	}

	//------------------------------------------------------------------------------------------------------------------
	private bool IsLightweightRenderPipelineMaterial(Material material)
	{
		return
			material.HasProperty("_MainTex") &&
			material.HasProperty("_BumpMap") &&
			material.HasProperty("_MetallicGlossMap") &&
			material.HasProperty("_OcclusionMap") &&
			material.HasProperty("_EmissionMap");
	}

	//------------------------------------------------------------------------------------------------------------------
	private void UpdateMaterial(Material material, int textureSize)
	{
		if (IsDefaultMaterial(material))
		{
			UpdateDefaultMaterial(material, textureSize);
		}
		else if (IsHighDefinitionRenderPipelineMaterial(material))
		{
			UpdateHighDefinitionRenderPipelineMaterial(material, textureSize);
		}
		else if (IsLightweightRenderPipelineMaterial(material))
		{
			UpdateLightweightRenderPipelineMaterial(material, textureSize);
		}
		else
		{
			Debug.LogError("Shader [" + material.shader.name + "] not supported. Game object [" + gameObject.name + "]");
		}
	}

	//------------------------------------------------------------------------------------------------------------------
	private void UpdateDefaultMaterial(Material material, int textureSize)
	{
		SetTexture(material, TextureType.Color, textureSize, "_MainTex", "", "_Color");
		SetTexture(material, TextureType.Normal, textureSize, "_BumpMap", "_NORMALMAP", "");
		SetTexture(material, TextureType.Height, textureSize, "_ParallaxMap", "_PARALLAXMAP", "");
		SetTexture(material, TextureType.Metallic, textureSize, "_MetallicGlossMap", "_METALLICGLOSSMAP", "");
		SetTexture(material, TextureType.Occlusion, textureSize, "_OcclusionMap", "", "");
		SetTexture(material, TextureType.Emission, textureSize, "_EmissionMap", "_EMISSION", "_EmissionColor");
	}

	//------------------------------------------------------------------------------------------------------------------
	private void UpdateHighDefinitionRenderPipelineMaterial(Material material, int textureSize)
	{
		SetTexture(material, TextureType.Color, textureSize, "_BaseColorMap", "", "_BaseColor");
		SetTexture(material, TextureType.Normal, textureSize, "_NormalMap", "_NORMALMAP", "");
		SetTexture(material, TextureType.Height, textureSize, "_HeightMap", "_HEIGHTMAP", "");
		SetTexture(material, TextureType.Metallic, textureSize, "_MaskMap", "_MASKMAP", "");
		SetTexture(material, TextureType.Emission, textureSize,"_EmissiveColorMap", "_EMISSIVE_COLOR_MAP", "_EmissiveColor");
	}

	//------------------------------------------------------------------------------------------------------------------
	private void UpdateLightweightRenderPipelineMaterial(Material material, int textureSize)
	{
		SetTexture(material, TextureType.Color, textureSize, "_MainTex", "", "_Color");
		SetTexture(material, TextureType.Normal, textureSize, "_BumpMap", "_NORMALMAP", "");
		SetTexture(material, TextureType.Metallic, textureSize, "_MetallicGlossMap", "_METALLICSPECGLOSSMAP", "");
		SetTexture(material, TextureType.Occlusion, textureSize, "_OcclusionMap", "_OCCLUSIONMAP", "");
		SetTexture(material, TextureType.Emission, textureSize, "_EmissionMap", "_EMISSION", "_EmissionColor");
	}

	//------------------------------------------------------------------------------------------------------------------
	private void SetTexture(
		Material material,
		TextureType textureType,
		int textureSize,
		string textureName,
		string keyword,
		string colorName)
	{
		if (keyword.Length > 0)
		{
			material.EnableKeyword(keyword);			
		}

		bool hasTexture = proTexTexture.HasTexture(textureType);
		
		if (hasTexture)
		{
			material.SetTexture(textureName, proTexTexture.GenerateTexture(textureSize, textureSize, textureType));
		}
		else
		{
			material.SetTexture(textureName, null);
		}
		
		if (colorName.Length > 0)
		{
			material.SetColor(colorName, hasTexture ? Color.white : Color.black);
		}
	}	
}
}