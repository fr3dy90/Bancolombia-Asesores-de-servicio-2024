Shader "Unlit/GreenRemoveWithFade"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ColorToRemove ("Color to Remove", Color) = (1,1,1,1)
        _Threshold ("Threshold", Range(0, 1)) = 0.1
        _GlobalAlpha ("Global Alpha", Range(0, 1)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100
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
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _ColorToRemove;
            float _Threshold;
            float _GlobalAlpha;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                if (distance(col.rgb, _ColorToRemove.rgb) < _Threshold)
                {
                    col.a = 0; // Make the pixel fully transparent if it matches the color to remove
                }

                col.a *= _GlobalAlpha; // Apply global alpha for fade effect

                return col;
            }
            ENDCG
        }
    }
}
