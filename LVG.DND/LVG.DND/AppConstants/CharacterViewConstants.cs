using LVG.DND.Views.characterviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.AppConstants
{
    internal class CharacterViewConstants
    {
        internal const string STATS_PAGE = "Stats";
        internal const string SKILLS_ABILITYSCORES_PAGE = "Skills and Ability Scores";
        internal const string FEATURES_AND_TRAITS_PAGE = "Features and Traits";
        internal const string WEAPONS_PAGE = "Weapons";
        internal const string SPELLS_PAGE = "Spells";
        internal const string INVENTORY_PAGE = "Inventory";
        internal const string PROFICIENCIES_PAGE = "Proficiencies";
        internal const string STORY_TELLING_PAGE = "Story Telling";
        internal const string SAVES_PAGE = "Saves";
        internal const string DEATHSAVES_PAGE = "Death Saves";

        internal ContentView GetCorrectPage(string requestString)
        {
            switch (requestString)
            {
                case STATS_PAGE:
                    return new CharacterStatsView();
                case SKILLS_ABILITYSCORES_PAGE:
                    return new CharacterStatsView();
                case FEATURES_AND_TRAITS_PAGE:
                    return new CharacterStatsView();
                case WEAPONS_PAGE:
                    return new CharacterStatsView();
                case SPELLS_PAGE:
                    return new CharacterStatsView();
                case INVENTORY_PAGE:
                    return new CharacterStatsView();
                case PROFICIENCIES_PAGE:
                    return new CharacterStatsView();
                case STORY_TELLING_PAGE:
                    return new CharacterStatsView();
                case SAVES_PAGE:
                    return new CharacterStatsView();
                case DEATHSAVES_PAGE:
                    return new CharacterStatsView();
                default:
                    return null;
            }
        }
    }
}
