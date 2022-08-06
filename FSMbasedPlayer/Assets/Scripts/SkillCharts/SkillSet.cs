using System;

namespace JlMetroidvaniaProject
{
    [Serializable]
    public class SkillSet
    {
        public SkillChart[] charts;

        public SkillSet(SkillChart[] charts)
        {
            int count = charts.Length;

            this.charts = new SkillChart[count];

            for(int i = 0; i < count; i++)
            {
                this.charts[i] = charts[i];
            }
        }

        public int Invest(int chart, int tree, int index, int point)
        {
            return charts[chart].Invest(tree, index, point);
        }

        public int Return(int chart, int tree, int index)
        {
            return charts[chart].Return(tree, index);
        }

        public SkillChart GetSkillChartByIndex(int index)
        {
            return charts[index];
        }
    }
}