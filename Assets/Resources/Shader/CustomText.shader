Shader "Custom/CustomText"
{
    Properties
    {
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Color("Text Color", Color) = (1,1,1,1)

    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard alpha:fade

        sampler2D _MainTex;
		float4 _Color;

        struct Input
        {
            float2 uv_MainTex;
		};

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Emission = _Color * 4.0f;
            o.Albedo = (1,1,0,0);
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
