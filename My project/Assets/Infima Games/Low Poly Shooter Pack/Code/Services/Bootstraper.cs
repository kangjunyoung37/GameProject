﻿//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Bootstraper.
    /// </summary>
    public static class Bootstraper
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            //Initialize default service locator.
            ServiceLocators.Initialize();
            
            //Game Mode Service.
            ServiceLocators.Current.Register<IGameModeService>(new GameModeService());
            
            #region Sound Manager Service

            //Create an object for the sound manager, and add the component!
            var soundManagerObject = new GameObject("Sound Manager");
            var soundManagerService = soundManagerObject.AddComponent<AudioManagerService>();
            
            //Make sure that we never destroy our SoundManager. We need it in other scenes too!
            Object.DontDestroyOnLoad(soundManagerObject);
            
            //Register the sound manager service!
            ServiceLocators.Current.Register<IAudioManagerService>(soundManagerService);

            #endregion
        }
    }
}