Shader "Custom/Basic Shader"
{
	Properties
	{
		_MainColor("Color", Color) = (1.0,1.0,1.0,1.0)
	}
		SubShader
	{
		Pass
		{
			CGPROGRAM
			
			float4 _Color;

			struct vertexInput
			{
				float4 vertex : POSITION;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
			};

			vertexOutput vert(vertexInput v)
			{

			}
			
			ENDCG
		}
	}
}
