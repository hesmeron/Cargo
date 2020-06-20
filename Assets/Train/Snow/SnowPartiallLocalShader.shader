Shader "Custom/SnowPartiallLocalShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Bump("Bump", 2D) = "bump" {}
		_Snow("Level of snow", Range(1,-1)) = 1
		_SnowColor("Color of snow", Color) = (1.0,1.0,1.0,1.0)
		_SnowDirection("Direction of snow", Vector) = (0,1,0)
		_SnowDepth("Depth of snow", Range(0,1)) = 0
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_MaxSize("MaxSize", Float) = 1
		_SnowPercentage("Snow Percentage", Range(0, 100)) = 0
		_Begining("Begining", Vector) = (200, 0, 200, 0)
		_RampTex("Ramp", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Toon vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _Bump;
		sampler2D _RampTex;
		float _Snow;
		float4 _SnowColor;
		float4 _Color;
		float4 _SnowDirection;
		float _SnowDepth;
		float _SnowPercentage;
		float _MaxSize;
		float3 _Begining;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_Bump;
			float3 worldNormal;
			float3 worldPos;
			float3 localPos;
			bool isPosition;
			INTERNAL_DATA
        };

        half _Glossiness;
        half _Metallic;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Bump));
			bool isAngle = dot(WorldNormalVector(IN, o.Normal), _SnowDirection.xyz) >= _Snow;
			_Begining = (0, 0, _Begining.z);
			IN.localPos = (0, 0, IN.localPos.z);
			float d = distance(_Begining, IN.localPos);
			bool isPosition = d / _MaxSize <= _SnowPercentage / 100.0;
			if (isAngle && isPosition) {
				o.Albedo = _SnowColor.rgb;
			}
			else {
				o.Albedo = c.rgb;
			}

			o.Alpha = 1;
        }

		void vert(inout appdata_full v, out Input o) {
			float4 sn = mul(UNITY_MATRIX_IT_MV, _SnowDirection);
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.localPos = v.vertex.xyz;
			//o.isPosition = v.vertex.x <= (((_SnowPercentage / 100.0) * 2) -1 )* _MeshRadius;
			if (dot(v.normal, sn.xyz) >= _Snow) {
				v.vertex.xyz += (sn.xyz + v.normal) * _SnowDepth * _Snow;
			}
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
