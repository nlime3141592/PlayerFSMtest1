using System;

namespace JlMetroidvaniaProject
{
    [Serializable]
    public class SkillChart
    {
        public SkillTree[] trees;

        public SkillChart(SkillTree[] trees)
        {
            int count = trees.Length;

            this.trees = new SkillTree[count];

            for(int i = 0; i < count; i++)
            {
                this.trees[i] = trees[i];
            }
        }

        public int Invest(int tree, int index, int point)
        {
            return trees[tree].Invest(index, point);
        }

        public int Return(int tree, int index)
        {
            return trees[tree].Return(index);
        }

        public SkillTree GetSkillTreeByIndex(int index)
        {
            return trees[index];
        }
    }
}