Shader "Unlit/ProgressBarShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Progress ("Progress", Range(0,1)) = 0.5
        _BarTint("BarTint",Color) = (1,1,1,1)
        _BarThickness("BarThickness", Range(0,1)) = 0.25
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Progress;
            float4 _BarTint;
            float _BarThickness;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 OutColor = (1,1,1,1);
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                
                UNITY_APPLY_FOG(i.fogCoord, col);
                float alpha = 0;
                float4 Gradient = (1,1,1,1);
                if(i.uv.y < 0.5)
                {
                    Gradient = i.uv.y + .5;
                }
                Gradient = pow(Gradient,10);
                _BarTint *= Gradient;
                if(i.uv.x < _Progress && i.uv.x < 0.97)
                {
                    alpha = 1;
                    
                }
                if(i.uv.y > 0.5 + _BarThickness/2 || i.uv.y < 0.5 - _BarThickness/2)
                {
                    alpha = 0;
                }
                _BarTint.a = alpha;
                OutColor = lerp(_BarTint, col, col.a);
                
                return OutColor;
            }
            ENDCG
        }
    }
}
