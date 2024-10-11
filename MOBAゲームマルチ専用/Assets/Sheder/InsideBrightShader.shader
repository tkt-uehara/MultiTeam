Shader "Custom/InsideBrightShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _Brightness ("Brightness", Range(0, 10)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normalDir : TEXCOORD0;
            };

            float _Brightness;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normalDir = normalize(mul((float3x3)unity_ObjectToWorld, v.normal));
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float brightnessFactor = dot(i.normalDir, float3(0,0,1)) < 0 ? _Brightness : 1;
                return half4(_Color.rgb * brightnessFactor, _Color.a);
            }
            ENDCG
        }
    }
}
