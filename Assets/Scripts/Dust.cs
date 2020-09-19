using DG.Tweening;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms = null;
    private BoxCollider _boxCollider = null;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void Clear()
    {
        _boxCollider.enabled = false;
        foreach (Transform t in _transforms)
        {
            t.DOScale(0.1f, 1f).onComplete += () => { t.DOKill(); Destroy(t.gameObject); };
        }
        Destroy(gameObject, 3f);
    }
}
