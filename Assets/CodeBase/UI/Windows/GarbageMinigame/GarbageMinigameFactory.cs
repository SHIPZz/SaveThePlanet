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
        private GarbageOptionInfo _lastOptionCreated;

        private List<GarbageOptionView> _createdViews = new();
        private UnityEngine.Canvas _canvas;

        public GarbageMinigameFactory(IInstantiator instantiator, GarbageMiniGameSO garbageMiniGameSo)
        {
            _instantiator = instantiator;
            _garbageMiniGameSo = garbageMiniGameSo;
            _garbageOptionInfos = garbageMiniGameSo.GarbageMinigameData.GarbageOptionInfos.ToList();
            _garbageAnswerDatas = garbageMiniGameSo.GarbageMinigameData.garbageAnswerDatas.ToList();
        }

        public void Init(UnityEngine.Canvas canvas)
        {
            _canvas = canvas;
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

        public void CleanUp()
        {
            _createdViews.ForEach(x =>
            {
                if (x != null)
                    Object.Destroy(x.gameObject);
            });

            if (_lastAnswerCreated != null)
                Object.Destroy(_lastAnswerCreated.gameObject);
            
            _createdViews.Clear();
            _garbageOptionInfos.Clear();
            _garbageAnswerDatas.Clear();
        }

        public IEnumerable<GarbageOptionInfo> CreateGarbageOptionViews(Transform parent, Vector3 at,
            UnityEngine.Canvas canvas)
        {
            if (_garbageOptionInfos.Count == 0)
                return null;

            var prefab = _garbageMiniGameSo.GarbageOptionViewPrefab;

            GarbageOptionView createdPrefab = null;
            List<GarbageOptionInfo> filteredGarbageOptions = null;

            for (int i = 0; i < OptionCount; i++)
            {
                if (_lastOptionCreated != null)
                {
                    filteredGarbageOptions = _garbageOptionInfos
                        .Where(option =>
                            !_createdViews
                                .Any(view => view.GarbageInfoPopupView.NameText.text.Equals(option.Name)))
                        .ToList();

                    ShuffleAndInsertOneCorrectOption(filteredGarbageOptions);
                }
                else
                {
                    filteredGarbageOptions = _garbageOptionInfos;
                }

                if (!filteredGarbageOptions.Any())
                    return null;

                CreateGarbageOptionViewPrefab(parent, at, filteredGarbageOptions, prefab,canvas);
            }

            return filteredGarbageOptions;
        }

        private void CreateGarbageOptionViewPrefab(Transform parent, Vector3 at,
            IEnumerable<GarbageOptionInfo> filteredGarbageOptions, GarbageOptionView prefab, UnityEngine.Canvas canvas)
        {
            GarbageOptionView createdPrefab;
            var randomOptionData = filteredGarbageOptions.ElementAt(Random.Range(0, filteredGarbageOptions.Count()));
            _lastOptionCreated = randomOptionData;

            createdPrefab = _instantiator
                .InstantiatePrefabForComponent<GarbageOptionView>(prefab, at, Quaternion.identity, parent)
                .With(x => x.GarbageInfoPopupView.NameText.text = randomOptionData.Name)
                .With(x => x.GarbageInfoPopupView.Icon.sprite = randomOptionData.Icon)
                .With(x => x.GarbageInfoPopupView.DescriptionText.text = randomOptionData.Description)
                .With(x => x.GarbageInfoPopupView.GarbageType = randomOptionData.GarbageType)
                .With(x => x.GarbageInfoPopupView.GetComponent<UIDraggableItem>().Init(canvas))
                .With(x => x.transform.localScale = Vector3.one);

            _createdViews.Add(createdPrefab);
        }

        private void ShuffleAndInsertOneCorrectOption(List<GarbageOptionInfo> filteredGarbageOptions)
        {
            if(filteredGarbageOptions.Count() != 0 )
                return;
            
            if (filteredGarbageOptions.All(x => x.GarbageType != _lastAnswerCreated.GarbageType))
            {
                var garbageOptionInfo = _garbageOptionInfos.Shuffle()
                    .FirstOrDefault(x => x.GarbageType == _lastAnswerCreated.GarbageType);

                List<GarbageOptionInfo> garbageOptionInfos = filteredGarbageOptions.ToList();
                garbageOptionInfos.RemoveAt(Random.Range(0, garbageOptionInfos.Count));
                garbageOptionInfos.Add(garbageOptionInfo);
            }
        }
    }
}