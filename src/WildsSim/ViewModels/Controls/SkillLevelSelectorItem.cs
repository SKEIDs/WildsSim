﻿using SimModel.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Xml.Linq;

namespace WildsSim.ViewModels.Controls
{
    internal class SkillLevelSelectorItem : ChildViewModelBase
    {
        /// <summary>
        /// 表示
        /// </summary>
        public string Disp { get; set; }

        /// <summary>
        /// 内部で使う値
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="disp">表示</param>
        /// <param name="level">内部で使う値</param>
        public SkillLevelSelectorItem(string disp, int level)
        {
            Disp = disp;
            Level = level;
        }

        /// <summary>
        /// 選択肢一覧の作成
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<SkillLevelSelectorItem> MakeSkillLevelSelectorItems(string skillName)
        {
            Skill baseSkill = Masters.Skills.Where(s => s.Name == skillName).First();
            ObservableCollection<SkillLevelSelectorItem> items = new();
            items.Add(new SkillLevelSelectorItem(baseSkill.Name, 0));
            for (int i = 1; i <= baseSkill.Level; i++)
            {
                if (!baseSkill.IsHideLevel(i))
                {
                    string dispName = baseSkill.SpecificNames.ContainsKey(i) ? $"{baseSkill.SpecificNames[i]}({baseSkill.Name}Lv{i})" : $"{baseSkill.Name}Lv{i}";
                    items.Add(new SkillLevelSelectorItem(dispName, i));
                }
            }
            return items;
        }
    }
}
