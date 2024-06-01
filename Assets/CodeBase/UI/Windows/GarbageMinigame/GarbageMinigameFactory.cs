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

        public GarbageAnswerCellView LastAnswerCreated => _lastAnswerCreated;

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
            _createdOptionDatas.Clear();

            if (_lastAnswerCreated != null)
                Object.Destroy(_lastAnswerCreated.gameObject);
        }

        public void CleanUp()
        {
            if (_lastAnswerCreated != null)
                Object.Destroy(_lastAnswerCreated.gameObject);

            _createdOptionDatas.Clear();
            _createdViewsToDestroy.Clear();
        }

        public IEnumerable<GarbageOptionInfo> CreateGarbageOptionViews(Transform parent, Vector3 at, UnityEngine.Canvas canvas)
        {
            if (_garbageOptionInfos.Count == 0)
                return null;

            var prefab = _garbageMiniGameSo.GarbageOptionViewPrefab;

            GarbageOptionInfo correctOption = GetRandomCorrectOption();
            
            if (correctOption == null)
                return null;

            _createdOptionDatas.Clear();

            List<GarbageOptionInfo> selectedOptions = new List<GarbageOptionInfo>();
            selectedOptions.Add(correctOption);

            while (selectedOptions.Count < OptionCount)
            {
                var randomOption = GetUniqueRandomOption(_garbageOptionInfos);
                
                if (randomOption != null && !selectedOptions.Contains(randomOption))
                {
                    selectedOptions.Add(randomOption);
                }
            }

            foreach (var option in selectedOptions)
            {
                CreateGarbageOptionViewPrefab(parent, at, option, prefab);
            }

            return selectedOptions;
        }

        private GarbageOptionInfo GetRandomCorrectOption()
        {
            return _garbageOptionInfos
                .Where(option => option.GarbageType == _lastAnswerCreated.GarbageType)
                .OrderBy(x => Random.value)
                .FirstOrDefault();
        }

        private void CreateGarbageOptionViewPrefab(Transform parent, 
            Vector3 at,
            GarbageOptionInfo optionData, 
            GarbageOptionView prefab)
        {
            var createdPrefab = _instantiator
                .InstantiatePrefabForComponent<GarbageOptionView>(prefab, at, Quaternion.identity, parent)
                .With(x => x.GarbageInfoPopupView.NameText.text = optionData.Name)
                .With(x => x.GarbageInfoPopupView.Icon.sprite = optionData.Icon)
                .With(x => x.GarbageInfoPopupView.DescriptionText.text = optionData.Description)
                .With(x => x.GarbageInfoPopupView.GarbageType = optionData.GarbageType)
                .With(x => x.transform.localScale = Vector3.one);

            _createdOptionDatas.Add(optionData);
            _createdViewsToDestroy.Add(createdPrefab);
        }

        private GarbageOptionInfo GetUniqueRandomOption(IEnumerable<GarbageOptionInfo> options)
        {
            List<GarbageOptionInfo> optionsList = options.ToList();
            GarbageOptionInfo randomOptionData = null;

            while (randomOptionData == null && optionsList.Count > 0)
            {
                int randomIndex = Random.Range(0, optionsList.Count);
                randomOptionData = optionsList[randomIndex];
                optionsList.RemoveAt(randomIndex);

                if (_createdOptionDatas.Contains(randomOptionData))
                {
                    randomOptionData = null;
                }
            }

            return randomOptionData;
        }
    }
}
