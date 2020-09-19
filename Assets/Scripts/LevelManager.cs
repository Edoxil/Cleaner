using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager = null;
    private LevelData _data = null;
    private int _levelNumber = 0;
    private int _dustCount = 0;
    private int _dustCleared = 0;
    [SerializeField] private GamePlayUI _gamePlayUI = null;

    public UnityEvent LevelCleared;

    void Start()
    {
        _gameManager = GameManager.GetInstance();
        _data = _gameManager.currentLevel;

        if (_data != null)
        {
            _levelNumber = _data.number;
            _dustCount = _data.dustPrefabs.Count;

            _gamePlayUI.SetLevelValue(_levelNumber);
            _gamePlayUI.SetProgressBarData(_dustCount);

        }
    }

    public void DustClearedHandler()
    {
        _dustCleared++;
        _gamePlayUI.ProgressBarForward();
        CheckClearStatus();
    }
    public void LoadNextLevel()
    {
        _gameManager.LoadNextLevel();
    }
    public void ReloadLevel()
    {
        _gameManager.ReloadLevel();
    }
    private void CheckClearStatus()
    {
        if (((float)_dustCount / 100) * 95 <= _dustCleared)
        {
            LevelCleared?.Invoke();
            foreach (Dust d in _data.dustPrefabs)
            {
                d.Clear();
                _gamePlayUI.ProgressBarForward();
            }
        }
    }
}
