Shader "Custom/CannonLine"
{
    Properties
    {
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_MainTex2("Albedo (RGB)", 2D) = "white" {}
		_Color("Color",color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:fade

		sampler2D _MainTex;
		sampler2D _MainTex2;
		float4 _Color;

        struct Input
        {
			float2 uv_MainTex;
			float2 uv_MainTex2;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			fixed4 d = tex2D(_MainTex2, float2(IN.uv_MainTex2.x + (_Time.y * -1), IN.uv_MainTex2.y));
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex + d.r) * _Color;
            o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
