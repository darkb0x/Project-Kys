using ProjectKYS.Cutscene;
using System.Collections.Generic;
using UnityEngine.Playables;

namespace ProjectKYS.Infrasturcture.Services.Cutscene
{
    public class CutsceneService : ICutsceneService
    {
        private Dictionary<string, PlayableDirector> _cutscenes;

        public CutsceneService()
        {
            
        }

        public void SetCutsceneList(Dictionary<string, PlayableDirector> cutscenes)
        {
            _cutscenes = cutscenes;
        }
        public void ResetCutsceneList()
        {
            _cutscenes?.Clear();
        }

        public void PlayCutscene(string key)
        {
            if (!_cutscenes.ContainsKey(key))
                return;

            _cutscenes[key].Play();
        }
    }
}
