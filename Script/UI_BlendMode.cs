using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BlendModes
{
    DEFAULT,

    DARKEN,
    MULTIPLY,
    COLOR_BURN,
    LINEAR_BURN,

    LIGHTEN,
    SCREEN,
    COLOR_DODGE,
    LINEAR_DODGE,

    OVERLAY,
    SOFT_LIGHT,
    HARD_LIGHT,
    VIVID_LIGHT,
    LINEAR_LIGHT,
    PIN_LIGHT,
    HARD_MIX,

    DIFFERENCE,
    EXCLUSION,
    SUBTRACT,
    DIVIDE,
    // 
}
[ExecuteInEditMode]
public class UI_BlendMode : MonoBehaviour
{
    [SerializeField]
    private BlendModes blendMode;
    private BlendModes prevBlendMode;

    private Image image;
    private RawImage rawImage;

    private Material mat;

    private void Awake()
    {
        image = GetComponent<Image>();
        rawImage = GetComponent<RawImage>();
    }
    private void Update()
    {
        if (prevBlendMode != blendMode)
        {
            SetMaterial();
            prevBlendMode = blendMode;
        }
    }

    private void SetMaterial()
    {
        if (image != null)
        {
            image.material = new Material(Shader.Find("UI/" + GetShaderNameFromType(blendMode)));
        }
        if (rawImage != null)
        {
            rawImage.material = new Material(Shader.Find("UI/" + GetShaderNameFromType(blendMode)));
        }
    }

    private string GetShaderNameFromType(BlendModes type)
    {
        if (type == BlendModes.DEFAULT)
        {
            return "Default";
        }

        string result = "Blend/";
        string[] split = type.ToString().ToLower().Split("_");

        for (int i = 0; i < split.Length; i++)
        {
            result += split[i][0].ToString().ToUpper() + split[i].Substring(1) + (i == split.Length - 1 ? "" : " ");
        }


        return result;
    }
    
}
