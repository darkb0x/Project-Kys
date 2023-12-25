using AYellowpaper.SerializedCollections;
using ProjectKYS.Infrasturcture.Services.Cutscene;
using ProjectKYS.Player;
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

        public Camera CutsceneCamera;
        [SerializeField] private CutsceneUtils _cutsceneUtils;
        [SerializeField] private List<CutsceneData> _cutscenes;

        private ICutsceneService _cutsceneService;


        public void Initialize(PlayerController player, ICutsceneService cutsceneService)
        {
            _cutsceneUtils.Intialize(player);
            _cutsceneService = cutsceneService;
            _cutsceneService.SetCutsceneData(player, ConvertCutsceneDataToDict(_cutscenes));
        }

        private void OnDestroy()
        {
            _cutsceneService.ResetCutsceneData();
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