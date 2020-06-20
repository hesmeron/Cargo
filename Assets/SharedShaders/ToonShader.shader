Shader "Custom/SimpleLambert"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_RampTex("Ramp", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Toon

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _RampTex;

        struct Input
        {
            float2 uv_MainTex;
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Alpha = c.a;
        }

		half4 LightingToon(SurfaceOutput s, half3 lightDir,
			half3 viewDir, half atten)
		{
			float NdotL = max(0, dot(s.Normal, lightDir));
			float _CelShadingLevels = 4.6;
			// Snap instead
			half cel = floor(NdotL * _CelShadingLevels) /
				(_CelShadingLevels - 0.5);

			// Next, set what color should be returned
			half4 color;

			color.rgb = s.Albedo * _LightColor0.rgb * (cel * atten);
			color.a = s.Alpha;

			// Return the calculated color
			return color;
		}
        ENDCG
    }
    FallBack "Diffuse"
}
