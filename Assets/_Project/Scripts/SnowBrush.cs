
using System;
using UnityEngine;
namespace LeonBrave{

public class SnowBrush : MonoBehaviour
{

    public CustomRenderTexture SnowHeightMap;
    public Material HeigtMapUpdate;

    private static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");

    private Camera _mainCamera;

    private void Start()
    {
        SnowHeightMap.Initialize();
        _mainCamera=Camera.main;
    }
    
    public void HeightMapUpdate(Vector4 hitCordinate)
    {
        HeigtMapUpdate.SetVector(DrawPosition,hitCordinate);
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(_mainCamera.transform.position, ray.direction * 10f, Color.red);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Vector2 hitCordinate = raycastHit.textureCoord;
                Debug.Log(raycastHit.collider.name+" "+hitCordinate);
               
                HeigtMapUpdate.SetVector(DrawPosition,hitCordinate);
            }
        }
    }


    private void OnApplicationQuit()
    {
        HeigtMapUpdate.SetVector(DrawPosition,new Vector4(-1,-1,0,0));
        SnowHeightMap.Initialize();
    }
}

}
