using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private List<float> _fpsValues = new List<float>();

    private float _updateInterval = 0.05f;

    private void Start()
    {
        StartCoroutine(UpdateFPSCounter());
        Application.targetFrameRate = 240;
    }

    private IEnumerator UpdateFPSCounter()
    {
        while (true)
        {
            _fpsValues.Add(1.0f / Time.unscaledDeltaTime);
            if (_fpsValues.Count >= 20)
            {
                _fpsValues.RemoveAt(0);
                _text.text = "FPS // " + Mathf.RoundToInt(_fpsValues.Average()).ToString();
            }
            
            yield return new WaitForSeconds(_updateInterval);
        }
    }
}
