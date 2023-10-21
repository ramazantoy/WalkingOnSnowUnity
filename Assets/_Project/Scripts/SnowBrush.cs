
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

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Vector2 hitCordinate = raycastHit.textureCoord;
                HeigtMapUpdate.SetVector(DrawPosition,hitCordinate);
            }
        }
    }
}

}
