using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace LeonBrave{

public class FpsHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text fpsText;

    int intFPS;

    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        intFPS = (int)fps;
        fpsText.text = intFPS.ToString();
    }
}

}
