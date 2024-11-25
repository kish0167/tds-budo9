using TDS.Service.Mission.ConcreteMissions;
using TDS.Service.Mission.Conditions;

namespace TDS.Service.Mission
{
    public class MissionFactory
    {
        #region Public methods

        public Mission Create(MissionCondition condition)
        {
            // TODO:
            if (condition is ReachExitPointMissionCondition reachExitPointMissionCondition)
            {
                ReachExitPointMission reachExitPointMission = new();
                reachExitPointMission.SetCondition(reachExitPointMissionCondition);
                return reachExitPointMission;
            }

            if (condition is KillEnemyMissionCondition killEnemyMissionCondition)
            {
                KillEnemyMission killEnemyMission = new();
                killEnemyMission.SetCondition(killEnemyMissionCondition);
                return killEnemyMission;
            }
            
            if (condition is OrCompositeMissionCondition orCompositeMissionCondition)
            {
                OrCompositeMission orCompositeMission = new();
                orCompositeMission.SetCondition(orCompositeMissionCondition);
                orCompositeMission.Setup(this);
                return orCompositeMission;
            }
            
            if (condition is AndCompositeMissionCondition andCompositeMissionCondition)
            {
                AndCompositeMission andCompositeMission = new();
                andCompositeMission.SetCondition(andCompositeMissionCondition);
                andCompositeMission.Setup(this);
                return andCompositeMission;
            }

            return null;
        }

        #endregion
    }
}