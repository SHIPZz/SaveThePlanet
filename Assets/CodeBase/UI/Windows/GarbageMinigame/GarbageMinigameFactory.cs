using System.Collections.Generic;
using System.Linq;
using CodeBase.Extensions;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageMinigameFactory
    {
        private const int OptionCount = 4;

        private readonly GarbageMiniGameSO _garbageMiniGameSo;
        private readonly IInstantiator _instantiator;

        private List<GarbageAnswerData> _garbageAnswerDatas;
        private List<GarbageOptionInfo> _garbageOptionInfos;
        private GarbageAnswerCellView _lastAnswerCreated;

        private List<GarbageOptionInfo> _createdOptionDatas = new();
        private List<GarbageOptionView> _createdViewsToDestroy = new();
        private List<string> _correctOptions = new();

        public GarbageMinigameFactory(IInstantiator instantiator, GarbageMiniGameSO garbageMiniGameSo)
        {
            _instantiator = instantiator;
            _garbageMiniGameSo = garbageMiniGameSo;
            _garbageOptionInfos = garbageMiniGameSo.GarbageMinigameData.GarbageOptionInfos.ToList();
            _garbageAnswerDatas = garbageMiniGameSo.GarbageMinigameData.garbageAnswerDatas.ToList();
        }

        public void AddCorrectView(string name) => _correctOptions.Add(name);

        public void Init()
        {
            _garbageOptionInfos = _garbageMiniGameSo.GarbageMinigameData.GarbageOptionInfos.ToList();
            _garbageAnswerDatas = _garbageMiniGameSo.GarbageMinigameData.garbageAnswerDatas.ToList();
        }

        public GarbageAnswerCellView CreateAnswerCellView(Transform parent, Vector3 at)
        {
            if (_garbageAnswerDatas.Count == 0)
                return null;

            var prefab = _garbageMiniGameSo.GarbageAnswerCellViewPrefab;

            var randomId = Random.Range(0, _garbageAnswerDatas.Count);

            var randomAnswerData = _garbageAnswerDatas[randomId];
            var createdPrefab = _instantiator.InstantiatePrefabForComponent<GarbageAnswerCellView>(prefab, at,
                    Quaternion.identity,
                    parent)
                .With(x => x.GarbageType = randomAnswerData.GarbageType)
                .With(x => x.Icon.sprite = randomAnswerData.Icon)
                .With(x => x.transform.localPosition = at)
                .With(x => x.Icon.enabled = true);

            _lastAnswerCreated = createdPrefab;
            return createdPrefab;
        }

        public void CleanUpCreatedViews()
        {
            _createdViewsToDestroy.ForEach(x =>
            {
                if (x != null)
                    Object.Destroy(x.gameObject);
            });

            _createdViewsToDestroy.Clear();
        }

        public void CleanUp()
        {
            if (_lastAnswerCreated != null)
                Object.Destroy(_lastAnswerCreated.gameObject);

            _createdOptionDatas.Clear();
        }

        public IEnumerable<GarbageOptionInfo> CreateGarbageOptionViews(Transform parent, Vector3 at,
            UnityEngine.Canvas canvas)
        {
            if (_garbageOptionInfos.Count == 0)
                return null;

            var prefab = _garbageMiniGameSo.GarbageOptionViewPrefab;

            GarbageOptionView createdPrefab = null;
            List<GarbageOptionInfo> filteredGarbageOptions = null;
            GarbageOptionInfo oneCorrectGarbageOption = null;

            for (int i = 0; i < OptionCount; i++)
            {
                if (_createdOptionDatas.Count != 0)
                {
                    filteredGarbageOptions = _garbageOptionInfos
                        .Where(option => !_correctOptions.Contains(option.Name))
                        .ToList();
                }
                else
                {
                    filteredGarbageOptions = _garbageOptionInfos;
                }

                if (!filteredGarbageOptions.Any())
                    return null;

                ShuffleAndInsertOneCorrectOption(ref filteredGarbageOptions, ref oneCorrectGarbageOption);
                
               if(CreateGarbageOptionViewPrefab(parent, at, filteredGarbageOptions, prefab, canvas) == null)
                   return null;
            }

            return filteredGarbageOptions;
        }

        private GarbageOptionView CreateGarbageOptionViewPrefab(Transform parent, 
            Vector3 at,
            IEnumerable<GarbageOptionInfo> filteredGarbageOptions, 
            GarbageOptionView prefab,
            UnityEngine.Canvas canvas)
        {
            GarbageOptionView createdPrefab;
            GarbageOptionInfo randomOptionData = GetUniqueRandomOption(filteredGarbageOptions);

            if (randomOptionData == null)
                return null;

            createdPrefab = _instantiator
                .InstantiatePrefabForComponent<GarbageOptionView>(prefab, at, Quaternion.identity, parent)
                .With(x => x.GarbageInfoPopupView.NameText.text = randomOptionData.Name)
                .With(x => x.GarbageInfoPopupView.Icon.sprite = randomOptionData.Icon)
                .With(x => x.GarbageInfoPopupView.DescriptionText.text = randomOptionData.Description)
                .With(x => x.GarbageInfoPopupView.GarbageType = randomOptionData.GarbageType)
                .With(x => x.GarbageInfoPopupView.GetComponent<UIDraggableItem>().Init(canvas))
                .With(x => x.transform.localScale = Vector3.one);

            _createdOptionDatas.Add(randomOptionData);
            _createdViewsToDestroy.Add(createdPrefab);
            return createdPrefab;
        }

        private void ShuffleAndInsertOneCorrectOption(ref List<GarbageOptionInfo> filteredGarbageOptions,
            ref GarbageOptionInfo oneCorrectGarbage)
        {
            if (filteredGarbageOptions.Count == 0)
                return;

            if (oneCorrectGarbage != null)
                return;

            oneCorrectGarbage = _garbageOptionInfos.Shuffle().FirstOrDefault(x => x.GarbageType == _lastAnswerCreated.GarbageType);
            filteredGarbageOptions.RemoveAt(Random.Range(0, filteredGarbageOptions.Count));
            filteredGarbageOptions.Add(oneCorrectGarbage);
        }

        private GarbageOptionInfo GetUniqueRandomOption(IEnumerable<GarbageOptionInfo> options)
        {
            GarbageOptionInfo randomOptionData = null;
            int maxAttempts = options.Count();

            while (randomOptionData == null && maxAttempts > 0)
            {
                randomOptionData = options.ElementAt(Random.Range(0, options.Count()));
                
                if (_createdOptionDatas.Contains(randomOptionData))
                {
                    randomOptionData = null;
                    maxAttempts--;
                }
            }

            return randomOptionData;
        }
    }
}