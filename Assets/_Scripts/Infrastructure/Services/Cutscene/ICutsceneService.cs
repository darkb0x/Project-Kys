using ProjectKYS.Cutscene;
using ProjectKYS.Player;
using System.Collections.Generic;
using UnityEngine.Playables;

namespace ProjectKYS.Infrasturcture.Services.Cutscene
{
    public interface ICutsceneService : IService
    {
        void SetCutsceneData(PlayerController player, Dictionary<string, PlayableDirector> cutscenes);
        void ResetCutsceneData();
        void PlayCutscene(string key);
    }
}
