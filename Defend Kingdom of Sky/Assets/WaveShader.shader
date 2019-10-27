//UNITY_SHADER_NO_UPGRADE
//Based on the WaveShader From Workshop
Shader "Unlit/WaveShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Pass
		{
			Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;	

			struct vertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
			};

			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{
			    half scale = 0.5;
			    half speed = 0.5;
			    half frequency = 1;
				// Displace the original vertex in model space
				half offsetVert = ((v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z));
                half value = scale * sin(_Time.y * speed + offsetVert * frequency);
                //float4 displacement = float4(0.0f, (offsetVert*0.1 + _Time.y), 0.0f, 0.0f); // Q5a

				v.vertex.y += value;

				vertOut o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				o.color = v.color;
				return o;


			}
			
			// Implementation of the fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, v.uv);
				
				return v.color;
			}
			ENDCG
		}
	}
}