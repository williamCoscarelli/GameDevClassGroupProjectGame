using System.Collections.Generic;
using UnityEngine;

public class Goalflag : MonoBehaviour

{
    public FBIAgentPlayer FbIAgentPlayer;
    public int currentlevel = 0;
    public List<GameObject> levels;
    private GameObject levelGameObject;

    void Start()
    {
        FbIAgentPlayer = FindAnyObjectByType<FBIAgentPlayer>();
        levelGameObject = CreateLevel();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FBIPlayer")
        {
            FbIAgentPlayer.Reset();
            GoToNextLevel();
        }
    }

    public void DoTheThing()
    {
        FbIAgentPlayer.Reset();
        GoToNextLevel();
    }

    private GameObject CreateLevel()
    {
        return Instantiate(levels[currentlevel], levels[currentlevel].transform.position, Quaternion.identity);
    }
    
    public  void GoToNextLevel()
    {
        currentlevel++;
        LoadNextLevel();
    }
    
    private void LoadNextLevel()
    {
        if (levelGameObject != null)
            Destroy(levelGameObject);
        levelGameObject = CreateLevel();
        
    }
}
