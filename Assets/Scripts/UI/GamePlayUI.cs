using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private Text _currentLevel = null;
    [SerializeField] private Text _nextLevel = null;
    [SerializeField] private Slider _progressBar = null;

    public void SetProgressBarData(int value)
    {
        _progressBar.minValue = 0;
        _progressBar.value = 0;
        _progressBar.maxValue = value;
    }
    public void ProgressBarForward()
    {
        _progressBar.value++;
    }
      

    public void SetLevelValue(int value)
    {
        _currentLevel.text = value.ToString();
        _nextLevel.text = (value + 1).ToString();
    }
}