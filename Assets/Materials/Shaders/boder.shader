Shader "Custom/boder"
{
 Properties
    {
        _Color("Outline Color", Color) = (.937, .827, .322, 1)
        _MainTex("Base (RGB)", 2D) = "white" { }
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Overlay"
        }

        Pass
        {
            Name "OUTLINE"

            ZWrite On
            ZTest LEqual
            Cull Front

            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            // The outline color will be used here
            Material {
                Diffuse [_Color]
            }
        }
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Overlay"
        }

        Pass
        {
            Name "OUTLINE"

            ZWrite On
            ZTest LEqual
            Cull Front

            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            // The outline color will be used here
            Material {
                Diffuse [_Color]
            }
        }

        // The original material without the outline
        Pass
        {
            Name "BASE"

            ZWrite On
            ZTest LEqual
            Cull Front

            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            Material {
                Diffuse [_MainTex]
            }
        }
    }
}
