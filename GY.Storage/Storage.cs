using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using LiteDB;
using Rocket.API;
using Rocket.API.Collections;
using Rocket.API.Extensions;
using Rocket.Core;
using Rocket.Core.Permissions;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace GY.Storage
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class Storage : RocketPlugin<Config>
    {
        public static Storage Instance;
        protected override void Load()
        {
            Instance = this;
            U.Events.OnPlayerConnected += EventsOnOnPlayerConnected;
            
            if (!System.IO.Directory.Exists(@"GY.DataBase"))
            {
                System.IO.Directory.CreateDirectory(@"GY.DataBase");
            }
        }

        private static void EventsOnOnPlayerConnected(UnturnedPlayer player)
        {
            player.Player.gameObject.AddComponent<StorageComponent>();
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            {"storage_block", "Вы не можете открыть Виртуальное Хранилище в транспорте!"},
            {"storage_not_allow", "У вас нет доступа к Виртуальному Хранилищу!"},
            {"storage_player_not", "Игрок не найден!"},
        };
    }
}