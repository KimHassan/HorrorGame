Shader "Unlit/Spotlight"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_CharacterPosition("Char pos", vector) = (0,0,0,0)
		_CircleRadius("Spotlight size", Range(0,20)) = 3
		_RingSize("Ring size", Range(0,5)) = 1
		_ColorTin("Outside of the spotlight color", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;

				float dist : TEXCOORD1; // world position of that vertex
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			float4 _CharacterPosition;
			float _CircleRadius;
			float _RingSize;
			float4 _ColorTint;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.dist = distance(worldPos, _CharacterPosition.xyz);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = (0,0,0,0);
               
				
				// This is the player's spotlight

				if (i.dist < _CircleRadius)
					col = tex2D(_MainTex, i.uv);
				else if (i.dist > _CircleRadius && i.dist < _CircleRadius + _RingSize)
				{
					float blendStrength = i.dist - _CircleRadius;
					col = lerp(tex2D(_MainTex, i.uv), _ColorTint, blendStrength / _RingSize);
				}

                return col;
            }
            ENDCG
        }
    }
}
