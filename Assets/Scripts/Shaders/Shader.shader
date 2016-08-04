Shader "Custom/Shader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white"{}
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata // Defines information from each vertex
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f   // Defines information that we are passing into fragment function
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v) {  // Takes appdata struct as parameter, and returns a v2f
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			float4 _Color;

			float4 frag(v2f i) : SV_Target // Takes v2f and returns a color
			{
				float4 col = tex2D(_MainTex, i.uv);
				col *= float4(i.uv.x, i.uv.y, 1, 1);
				return col;
			}
			ENDCG
		}
	}
}