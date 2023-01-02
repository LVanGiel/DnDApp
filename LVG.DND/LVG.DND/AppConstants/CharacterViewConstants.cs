using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;
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
        internal Character character = new Character();
        internal Streaming _stream = new Streaming();

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

        internal async Task<ContentView> GetCorrectPage(string requestString)
        {
            character = await _stream.LoadCharacter();
            switch (requestString)
            {
                case STATS_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case SKILLS_ABILITYSCORES_PAGE:
                    return new CharacterSkillsAndAbilitiesView(new CharacterSkillsAndAbilityscoresViewModel());
                case FEATURES_AND_TRAITS_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case WEAPONS_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case SPELLS_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case INVENTORY_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case PROFICIENCIES_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case STORY_TELLING_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case SAVES_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                case DEATHSAVES_PAGE:
                    return new CharacterStatsView(new CharacterStatsViewModel());
                default:
                    return null;
            }
        }
    }
}
