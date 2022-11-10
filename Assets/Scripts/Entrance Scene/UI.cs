using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
      Button _button;
    
    void Start()
    {
        _button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextscene = sceneIndex + 1;
            SceneManager.LoadScene(nextscene);
        } 
    }
}
