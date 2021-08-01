using Unity.LEGO.Game;
using System.Collections.Generic;
using UnityEngine;
namespace Unity.LEGO.UI
{
    public class WinSceneButton : LoadSceneButton
    {
        // Start is called before the first frame update
        void Start()
        {
            OnStart();
        }

        // Update is called once per frame
        protected override void OnStart()
        {
            sceneName = "Menu Intro";
        }
    }
}
