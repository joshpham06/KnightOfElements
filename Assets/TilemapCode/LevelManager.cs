using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject LevelOne;
    public GameObject LevelTwo;
    public GameObject LevelThree;
    public GameObject[] Levels; 
    public WaveManager WaveManager;
    private int currentLevelIndex = 0; 

    public void Awake()
    {
        
       
        
    }

    public void Update()
    {
        if (WaveManager.IsSpawning == 0)
        {
            nextLevel();
        }
    }

    public void Start()
    {
        
        Levels[0] = LevelOne;
        Levels[1] = LevelTwo;
        Levels[2] = LevelThree;
        Levels[0].SetActive(true);
        
        
    }


    public void nextLevel()
    {


        if (currentLevelIndex == 0)
        {
            LevelOne.SetActive(false);
            LevelTwo.SetActive(true);
        }
        if (currentLevelIndex == 1)
        {
            LevelTwo.SetActive(false);
            LevelThree.SetActive(true);
        }

        if (currentLevelIndex < 2)
        {
            currentLevelIndex++;
        }
        
    }
    
}
