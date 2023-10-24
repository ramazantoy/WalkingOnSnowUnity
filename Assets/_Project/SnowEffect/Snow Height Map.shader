Shader "Snow Height Map Update"
{
    Properties
    {
       _DrawPosition("Draw Position" ,Vector)=(-1,-1,0,0)
       _RemovePosition("Remove Position",Vector)=(-1,-1,0,0)
       _CanRemove("Can Remove",float)=0
    }

    SubShader
    {
        Lighting Off
        Blend One Zero
        
        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0
            
            float4 _DrawPosition;
            float4 _RemovePosition;
            float _CanRemove;
            
            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                float4 previousColor = tex2D(_SelfTexture2D, IN.localTexcoord.xy);
                
                    if(_CanRemove==1.0 && distance(IN.localTexcoord.xy, _RemovePosition) < 0.01)
                {
                    return float4(1, 1, 1, 0); 
                }
                float4 drawColor = smoothstep(.002,.01,distance(IN.localTexcoord.xy,_DrawPosition));
                
                return min(previousColor,drawColor);
            }
            ENDCG
        }
    }
}
