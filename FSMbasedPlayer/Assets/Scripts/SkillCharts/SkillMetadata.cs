using System;

namespace JlMetroidvaniaProject
{
    [Serializable]
    public struct SkillMetadata
    {
        public string name;
        public string description;
        public int id;
        public int cost;
        public int level;
        public bool isInvested;
    }
}