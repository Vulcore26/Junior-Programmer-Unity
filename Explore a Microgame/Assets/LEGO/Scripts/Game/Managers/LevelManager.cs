using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.LEGO.Game
{
    public class LevelManager : MonoBehaviour
    {
        public string currentLevel;
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += ScencChange;
        }

        private void ScencChange(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.name.StartsWith("LEGO Level "))
                currentLevel = arg0.name;
        }
    }
}
