using ProjectKYS.Cutscene;
using ProjectKYS.Player;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectKYS.Infrasturcture.Services.Cutscene
{
    public class CutsceneService : ICutsceneService
    {
        public static Action OnCutsceneEnd;

        private readonly MonoBehaviour _monoBehaviour;

        private Dictionary<string, PlayableDirector> _cutscenes;
        private PlayerController _player;

        public CutsceneService(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }

        private void InvokeCutsceneEnd(PlayableDirector playable)
        {
            OnCutsceneEnd?.Invoke();
            playable.stopped -= InvokeCutsceneEnd;
            _player.SetEnabled(true);
        }

        public void SetCutsceneData(PlayerController player, Dictionary<string, PlayableDirector> cutscenes)
        {
            _player = player;
            _cutscenes = cutscenes;
        }
        public void ResetCutsceneData()
        {
            _cutscenes?.Clear();
        }

        public void PlayCutscene(string key)
        {
            if (!_cutscenes.ContainsKey(key))
                return;

            _player.SetEnabled(false);

            _cutscenes[key].Play();
            _cutscenes[key].stopped += InvokeCutsceneEnd;
        }
    }
}
