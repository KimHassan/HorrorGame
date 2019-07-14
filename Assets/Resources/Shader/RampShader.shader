Shader "Custom/RampShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_Intensity ("Intensity", Range(0, 100)) = 0
		_MainRamp("Ramp", 2D) = "White" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainRamp;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
		float _Intensity;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = _Color;
			float4 ramp = tex2D(_MainRamp, float2(_Time.y * 0.1f, 10));

            o.Albedo = c.rgb * ramp.r;
            o.Alpha = c.a;
			o.Emission = c.rgb * _Intensity * ramp.r;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
