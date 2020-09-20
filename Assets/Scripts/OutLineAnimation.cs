using UnityEngine;

public class OutLineAnimation : MonoBehaviour
{
    private Renderer _renderer = null;

    private Color _baseOutlineColor;
    private Color _changedColor;

    private float _timeElapsed = 0f;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();


        _baseOutlineColor = _renderer.material.GetColor("_OutlineColor");
        _changedColor = Color.red;
    }


    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= 0.3f)
        {

            _renderer.material.SetColor("_OutlineColor", _changedColor);
        }
        if (_timeElapsed >= 0.7f)
        {
            _renderer.material.SetColor("_OutlineColor", _baseOutlineColor);
            _timeElapsed = 0f;
        }

    }
}