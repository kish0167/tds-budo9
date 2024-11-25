using System.Collections.Generic;
using TDS.Service.Mission.Conditions;
using TDS.Utils.Log;

namespace TDS.Service.Mission.ConcreteMissions
{
    public class AndCompositeMission : Mission<AndCompositeMissionCondition>
    {
        #region Variables

        private readonly List<Mission> _missions = new();

        private MissionFactory _factory;

        #endregion

        #region Public methods

        public void Setup(MissionFactory factory)
        {
            _factory = factory;
        }

        #endregion

        #region Protected methods

        protected override void OnBegin()
        {
            base.OnBegin();

            foreach (MissionCondition missionCondition in Condition.Conditions)
            {
                Mission mission = _factory.Create(missionCondition);
                mission.OnCompleted += MissionCompletedCallback;
                mission.Begin();
                _missions.Add(mission);
            }
        }

        protected override void OnStop()
        {
            base.OnStop();

            foreach (Mission mission in _missions)
            {
                mission.OnCompleted -= MissionCompletedCallback;
                mission.Stop();
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            foreach (Mission mission in _missions)
            {
                mission.Update();
            }
        }

        #endregion

        #region Private methods

        private void MissionCompletedCallback()
        {
            foreach (Mission mission in _missions)
            {
                if (!mission.IsCompleted)
                {
                    return;
                }
            }
            
            this.Error("Mission ('and' composite) completion invoke");
            InvokeCompletion();
        }

        #endregion
    }
}