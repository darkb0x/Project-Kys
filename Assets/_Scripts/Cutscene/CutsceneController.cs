using AYellowpaper.SerializedCollections;
using ProjectKYS.Infrasturcture.Services.Cutscene;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectKYS.Cutscene
{
    public class CutsceneController : MonoBehaviour
    {
        [Serializable]
        private struct CutsceneData
        {
            public string Key;
            public PlayableDirector Cutscene;
        }

        [SerializeField] private List<CutsceneData> _cutscenes;

        private ICutsceneService _cutsceneService;

        private void Awake()
        {
            _cutsceneService = ServiceLocator.Instance.Get<ICutsceneService>();
            _cutsceneService.SetCutsceneList(ConvertCutsceneDataToDict(_cutscenes));
        }

        private void OnDestroy()
        {
            _cutsceneService.ResetCutsceneList();
        }

        private Dictionary<string, PlayableDirector> ConvertCutsceneDataToDict(List<CutsceneData> cutsceneDatas)
        {
            Dictionary<string, PlayableDirector> result = new Dictionary<string, PlayableDirector>();

            foreach (var item in cutsceneDatas)
            {
                if (string.IsNullOrEmpty(item.Key))
                    continue;
                if (item.Cutscene == null)
                    continue;

                result.Add(item.Key, item.Cutscene);
            }

            return result;
        }
    }
}