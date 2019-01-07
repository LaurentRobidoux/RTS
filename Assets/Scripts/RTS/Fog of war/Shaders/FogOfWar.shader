Shader "Custom/FogOfWarMask" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_ExploredTex("Explored Area", 2D) = "white" {}
		_VisibleTex("Visible Area", 2D) = "white" {}
	_BlurPower("BlurPower", float) = 0.002
	}
		SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		//Lighting off
		//LOD 200

		CGPROGRAM
#pragma surface surf Lambert alpha:blend
#pragma target 3.0

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, float aten) {
		fixed4 color;
		color.rgb = s.Albedo;
		color.a = s.Alpha;
		return color;
	}

	fixed4 _Color;
	sampler2D _ExploredTex;
	sampler2D _VisibleTex;
	float _BlurPower;

	struct Input {
		float2 uv_ExploredTex;
		float2 uv_VisibleTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		half4 baseColor1 = tex2D(_ExploredTex, IN.uv_ExploredTex + float2(-_BlurPower, 0));
		half4 baseColor2 = tex2D(_ExploredTex, IN.uv_ExploredTex + float2(0, -_BlurPower));
		half4 baseColor3 = tex2D(_ExploredTex, IN.uv_ExploredTex + float2(_BlurPower, 0));
		half4 baseColor4 = tex2D(_ExploredTex, IN.uv_ExploredTex + float2(0, _BlurPower));
	//	half4 baseColor = 0.25 * (baseColor1 + baseColor2 + baseColor3 + baseColor4);
		half4 exploredColor = tex2D(_ExploredTex, IN.uv_ExploredTex);
		half4 visibleColor = tex2D(_VisibleTex, IN.uv_VisibleTex);
			half4 baseColor = exploredColor;
			o.Albedo = baseColor.rgb* baseColor.b;
			o.Alpha = max( 1 - baseColor.g*0.5-visibleColor.g,0);
	}
	ENDCG
	}
		Fallback "Diffuse"
}﻿