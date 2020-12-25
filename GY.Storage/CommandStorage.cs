using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using UnityEngine;
using static GY.Storage.Storage;

namespace GY.Storage
{
    public class CommandStorage : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "Vault";
        public string Help => "";
        public string Syntax => "";
        public List<string> Aliases => new List<string>{"storage", "s"};
        public List<string> Permissions => new List<string>{"gy.storage"};
        
        public void Execute(IRocketPlayer caller, string[] command)
        {
            var player = (UnturnedPlayer) caller;
            player.Player.GetComponent<StorageComponent>().OpenStorage();
        }
    }
}