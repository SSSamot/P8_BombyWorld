Shader "Learning/Unlit/TO RENAME"
{
    Properties
    {   
        _Texture("Character_Texture", 2D) = "white" {}
        _HitColor("HitColor", Color) = (1,0,0,1)
        _LastHit("LastHitTime",Float) = 0
        _BorderSize("BorderSize",Range(0,1)) = 0
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
            float _BorderSize;
			
			struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 ws_normal : TEXCOORD1;
                float3 ws_Pos : TEXCOORD2;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv;
                o.ws_normal = normalize(mul(unity_ObjectToWorld, float4(v.normal, 0))).xyz;
                o.ws_Pos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 tex = tex2D(_Texture, i.uv); 

                float3 V = normalize(_WorldSpaceCameraPos - i.ws_Pos);
                float3 N = normalize(i.ws_normal);
                float res = floor(dot(N, V)+ _BorderSize);
                tex = lerp(float4(0, 0, 0, 0), tex, res);
                return lerp(tex, _HitColor, clamp(_LastHit-_Time.x*20,0,0.8));
            }
            
            ENDHLSL
        }
    }
}
