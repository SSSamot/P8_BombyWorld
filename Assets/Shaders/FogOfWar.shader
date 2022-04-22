Shader "Learning/Unlit/FogOfWar"
{
    Properties
    {   
       _Albedo("Albedo", 2D) = "white" {}
       _FOW("FOW", 2D) = "white" {}
    }

        SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _Albedo;
            sampler2D _FOW;
			
			struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 col = tex2D(_Albedo, i.uv);
                float a = tex2D(_FOW, i.uv);
                return float4(col.rgba*a.r); 
            }
            
            ENDHLSL
        }
    }
}
