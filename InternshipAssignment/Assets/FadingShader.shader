Shader "Custom/FadingShader" {
    Properties {
        _Color ("Main Color", Color) = (1, 1, 1, 1)
        _RedColor ("Red Color", Color) = (1, 0, 0, 1)
    }
    SubShader {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float4 _Color;
            float4 _RedColor; // Add the red color property
            
            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = lerp(col.rgb, _RedColor.rgb, _RedColor.a); // Apply the red color
                col.a *= _Color.a; // Apply fading to alpha channel
                return col;
            }
            ENDCG
        }
    }
}
