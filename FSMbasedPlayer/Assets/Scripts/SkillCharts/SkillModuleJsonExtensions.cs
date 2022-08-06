using UnityEngine;

namespace JlMetroidvaniaProject
{
    public static class SkillModuleJsonExtensions
    {
        public static string ToJson(this SkillMetadata data, bool prettyPrint = false)
        {
            return JsonUtility.ToJson(data, prettyPrint);
        }

        public static string ToJson(this SkillTree tree, bool prettyPrint = false)
        {
            return JsonUtility.ToJson(tree, prettyPrint);
        }

        public static string ToJson(this SkillChart chart, bool prettyPrint = false)
        {
            return JsonUtility.ToJson(chart, prettyPrint);
        }

        public static string ToJson(this SkillSet set, bool prettyPrint = false)
        {
            return JsonUtility.ToJson(set, prettyPrint);
        }

        public static void FromJsonOverwrite(this SkillMetadata data, string json)
        {
            JsonUtility.FromJsonOverwrite(json, data);
        }

        public static void FromJsonOverwrite(this SkillTree tree, string json)
        {
            JsonUtility.FromJsonOverwrite(json, tree);
        }

        public static void FromJsonOverwrite(this SkillChart chart, string json)
        {
            JsonUtility.FromJsonOverwrite(json, chart);
        }

        public static void FromJsonOverwrite(this SkillSet set, string json)
        {
            JsonUtility.FromJsonOverwrite(json, set);
        }
    }
}