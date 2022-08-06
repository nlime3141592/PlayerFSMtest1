using System;

namespace JlMetroidvaniaProject
{
    [Serializable]
    public class SkillTree
    {
        public SkillMetadata[] metadatas;
        public int maxInvestedLevel;

        public SkillTree(SkillMetadata[] datas)
        {
            int count = datas.Length;

            metadatas = new SkillMetadata[count];

            for(int i = 0; i < count; i++)
            {
                metadatas[i] = datas[i];
            }

            maxInvestedLevel = m_GetMaxInvestedLevel();
        }

        public int Invest(int index, int point)
        {
            int pointChanges = 0;
            int cost = metadatas[index].cost;
            int level = metadatas[index].level;

            if(!metadatas[index].isInvested && point >= cost && level <= maxInvestedLevel + 1)
            {
                pointChanges = -cost;
                metadatas[index].isInvested = true;
                maxInvestedLevel = m_GetMaxInvestedLevel();
            }

            return pointChanges;
        }

        public int Return(int index)
        {
            int pointChanges = 0;
            int cost = metadatas[index].cost;
            int level = metadatas[index].level;

            if(metadatas[index].isInvested && level == maxInvestedLevel)
            {
                pointChanges = cost;
                metadatas[index].isInvested = false;
                maxInvestedLevel = m_GetMaxInvestedLevel();
            }

            return pointChanges;
        }

        public SkillMetadata GetSkillDataByIndex(int index)
        {
            return metadatas[index];
        }

        public SkillMetadata GetSkillDataByID(int id)
        {
            int count = metadatas.Length;

            for(int i = 0; i < count; i++)
            {
                if(metadatas[i].id == id)
                {
                    return metadatas[i];
                }
            }

            return default(SkillMetadata);
        }

        private int m_GetMaxInvestedLevel()
        {
            int max = 0;

            for(int i = 0; i < metadatas.Length; i++)
            {
                int level = metadatas[i].level;

                if(level > max)
                    max = level;
            }

            return max;
        }
    }
}