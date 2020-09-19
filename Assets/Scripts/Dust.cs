using DG.Tweening;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms;

    public void Disolve()
    {
        foreach (Transform t in _transforms)
        {
            t.DOScale(0.1f, 1f).onComplete += () => { t.DOKill(); Destroy(t.gameObject); };
        }
        Destroy(gameObject, 3f);
    }
}
