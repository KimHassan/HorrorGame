Shader "Custom/3dText"
{
	Properties{
		_MainTex("Font Texture", 2D) = "white" {}
		_Color("Text Color", Color) = (1,1,1,1)
		_EmissionMap("Emission map", 2D) = "black" {}
		_EmissionColor("Emission Color", Color) = (0,0,0)
	}

	SubShader{
		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Lighting Off Cull Off ZWrite Off Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		Pass {
			Color[_Color]
			SetTexture[_MainTex] {
				combine primary, texture * primary
			}
		}
	}
	FallBack "Diffuse"
}
