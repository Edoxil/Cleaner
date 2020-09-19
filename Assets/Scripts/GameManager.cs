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
        // TMP  
        Debug.Log("DONT FORGET");
        PlayerPrefs.SetInt("level", 0);


        LoadLevel();
    }

 

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
    public void LoadNextLevel()
    {
        int index = PlayerPrefs.GetInt("level", 0);
        index++;
        PlayerPrefs.SetInt("level", index);
        _levelIndex = PlayerPrefs.GetInt("level", 0);
        LoadLevel();
    }
    public void ReloadLevel()
    {
        LoadLevel();
    }
}