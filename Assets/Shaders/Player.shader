Shader "Learning/Unlit/TO RENAME"
{
    Properties
    {   
        _Texture("Texture", 2D) = "white" {}
        _HitColor("HitColor", Color) = (1,0,0,1)
        _LastHit("LastHitTime",Float) = 0
    }
    
    SubShader
    {
		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _Texture;
            float4 _HitColor;
            float _LastHit;
			
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
                return lerp(tex2D(_Texture, i.uv), _HitColor, clamp(_LastHit-_Time.x*20,0,0.8));
            }
            
            ENDHLSL
        }
    }
}
