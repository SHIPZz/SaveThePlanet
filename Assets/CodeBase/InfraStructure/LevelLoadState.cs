﻿using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.ScriptableObjects;
using CodeBase.Services.WorldData;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.InfraStructure
{
    public class LevelLoadState : IState, IEnter
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private IWorldDataService _worldDataService;

        public LevelLoadState(ILoadingCurtain loadingCurtain, IWorldDataService worldDataService)
        {
            _worldDataService = worldDataService;
            _loadingCurtain = loadingCurtain;
        }

        public async void Enter()
        {
            _loadingCurtain.Show(2.5f);

#if UNITY_EDITOR
            _worldDataService.WorldData.TutorialData.Completed = EditorPrefs.GetBool("TUTORIAL");
#endif

            AsyncOperation asyncOperation =  SceneManager.LoadSceneAsync(sceneBuildIndex: 1);

            while (asyncOperation.isDone == false) 
                await UniTask.Yield();

            _loadingCurtain.Hide();
        }
    }
}