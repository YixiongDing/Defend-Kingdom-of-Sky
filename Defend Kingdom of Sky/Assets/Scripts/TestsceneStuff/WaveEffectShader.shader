Shader "Effects/WaveEffect"
{
	Properties
	{
	    _NoiseTex("Texture (R,G=X,Y Distortion; B=Mask; A=Unused)", 2D) = "white" {}
	    _TimeControl("Time passed since the object was created", float) = 0
	}
	SubShader
	{
		// Draw ourselves after all opaque geometry
		Tags{ "Queue" = "Transparent" }

		// Grab the screen behind the object into _BackgroundTexture
		GrabPass
	    {
		    "_BackgroundTexture"
	    }

		Cull Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Off
		Pass
	    {
		    CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float _TimeControl;
	        struct v2f 
	        {
                float4 grabPos : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

	        v2f vert(appdata_full v) {
	            
	            float expandFactor = 100;
		        v2f o;
                //v.vertex.xyz += v.normal.xyz *_TimeControl* expandFactor;

		        // use UnityObjectToClipPos from UnityCG.cginc to calculate 
		        // the clip-space of the vertex
		        o.pos = UnityObjectToClipPos(v.vertex);
                // use ComputeGrabScreenPos function from UnityCG.cginc
		        // to get the correct texture coordinate
                o.grabPos = ComputeGrabScreenPos(o.pos);
		
		        return o;
            }

	        sampler2D _BackgroundTexture;
	        sampler2D _NoiseTex;
	        
	        float4 _NoiseTex_ST;

	        half4 frag(v2f i) : SV_Target
	        {
	            float intensity = 0.5;
		        half4 d = tex2D(_NoiseTex, i.grabPos);
		        float4 p = i.grabPos + (d * intensity);

		        half4 bgcolor = tex2Dproj(_BackgroundTexture, p);
		
		
		
		        return bgcolor;
            }
		    ENDCG
	    }
	}
}