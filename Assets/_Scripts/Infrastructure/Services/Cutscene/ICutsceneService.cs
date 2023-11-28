using ProjectKYS.Cutscene;
using System.Collections.Generic;
using UnityEngine.Playables;

namespace ProjectKYS.Infrasturcture.Services.Cutscene
{
    public interface ICutsceneService : IService
    {
        void SetCutsceneList(Dictionary<string, PlayableDirector> cutscenes);
        void ResetCutsceneList();
    }
}
