﻿using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class CharacterStatsViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character;

        Streaming _stream = new Streaming();
        public CharacterStatsViewModel()
        {
            LoadCharacter();
        }
        private async void LoadCharacter()
        {
            character = await _stream.LoadCharacter();
        }
    }
}