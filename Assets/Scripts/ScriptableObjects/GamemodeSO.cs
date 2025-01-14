using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GamemodeSO", menuName = "ScriptableObjects/GamemodeSO")]
public class GamemodeSO : ScriptableObject
{
    [System.Serializable]
    public class GamemodeIntVariable
    {
        //public string owner;
        public string name;
        //public int targetValue;
        //public int value;
        public TargetValue[] targetValues;

        [System.Serializable]
        public class TargetValue
        {
            public int targetValue;
            public enum Actions { ResetVariable, DetermineVictor, PlayerVictory, EliminatePlayer }
            public Actions[] OnTargetReached;

            public enum OperationType { Equal, EqualOrMore, EqualOrLess, NotEqual };
            public OperationType CheckType;
            //public UnityEvent<string> OnTargetReached;

            private bool CheckTargetEqual(int val)
            {
                if (val == targetValue)
                {
                    //OnTargetReached.Invoke(ownr);
                    return true;
                }

                return false;
            }

            private bool CheckTargetEqualOrMore(int val)
            {
                if (val >= targetValue)
                {
                    //OnTargetReached.Invoke(ownr);
                    return true;
                }

                return false;
            }

            private bool CheckTargetEqualOrLess(int val)
            {
                if (val <= targetValue)
                {
                    //OnTargetReached.Invoke(ownr);
                    return true;
                }

                return false;
            }

            public Actions[] GetTargetValueAction()
            {
                return OnTargetReached;
            }

            public bool CheckTarget(int val)
            {
                switch (CheckType)
                {
                    case OperationType.Equal:
                        return CheckTargetEqual(val);
                    case OperationType.EqualOrLess:
                        return CheckTargetEqualOrLess(val);
                    case OperationType.EqualOrMore:
                        return CheckTargetEqualOrMore(val);
                    case OperationType.NotEqual:
                        return !CheckTargetEqual(val);
                    default:
                        return false;
                }
            }
        }

        public bool CheckValue(int val)
        {
            foreach (var v in targetValues)
            {
                if (v.CheckTarget(val))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public bool hidden = false;
    public string gamemodeID;
    public string gamemodeName;
    [TextArea] public string gamemodeDescription;


    public GamemodeIntVariable[] globalVariables;

    public GamemodeIntVariable[] playerVariables;

    [Header("Team Settings")]
    public bool teamBased = false; //Not used
    public string[] teams; //Not used
    public bool allowPlayersToChangeTeams = true; //Not used

    [Header("Life Settings")]
    public int basicLivesPerPlayer = 5;
    public bool eachLifeHasAName = true;
    public bool livesSharedAccrossTeam = false; //Not used
}
