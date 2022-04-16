Shader "Learning/Unlit/Bomb"
{
    Properties
    {   
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Albedo("Main Albedo", 2D) = "black" {}
        _Color("Color", Color) = (1,1,1,1)
        _PlayerPos("Player Pos", Vector) = (0,0,0,0)
        _Target("Target", Vector) = (0,0,0,0)
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
            float4 _Color;
            float3 _PlayerPos;
            float3 _Target;
			
			struct vertexInput
            {
                float4 vertex : POSITION;	
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION; 
                float2 uv : TEXCOORD0;
                float3 worldSpacePos : TEXCOORD1;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float d = distance(_Target, i.worldSpacePos);
            
                //return tex2D(_Albedo, i.uv);
                return d < 5 ? tex2D(_Albedo, i.uv) : _Color;
            }
            
            ENDHLSL
        }
    }
}
