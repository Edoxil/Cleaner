using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager _instance = null;
    public static GameManager GetInstance()
    {
        return _instance;
    }
    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion Singleton



    [SerializeField] private List<LevelData> levelData = null;
    [HideInInspector] public LevelData currentLevel = null;


    private GameObject _levelInstance = null;
    private int _levelIndex = 0;




    void Start()
    {
        
        PlayerPrefs.SetInt("level", 0); //  Удалить если нужно сохранять прогресс
        LoadLevel();
    }

    // Загрузка префаба уровня по индексу сохраненному в PlayerPrefs.GetInt("level", 0);
    public void LoadLevel()
    {
        if (_levelInstance != null)
        {
            Destroy(_levelInstance);
        }

        _levelIndex = PlayerPrefs.GetInt("level", 0);
        currentLevel = levelData[_levelIndex];
        _levelInstance = Instantiate(levelData[_levelIndex].levelPrefab, transform.position, Quaternion.identity, transform);
    }

    // Инкрементируем индекс и загружаем префаб уровня с новым индексом
    public void LoadNextLevel()
    {
        int index = PlayerPrefs.GetInt("level", 0);
        index++;
        if (index < levelData.Count)
        {
            PlayerPrefs.SetInt("level", index);
        }

        _levelIndex = PlayerPrefs.GetInt("level", 0);
        LoadLevel();
    }

    // Загрузить текущий уровень заново
    public void ReloadLevel()
    {
        LoadLevel();
    }
}



