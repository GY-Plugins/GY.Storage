using System;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;
using static GY.Storage.Storage;
using Logger = Rocket.Core.Logging.Logger;

namespace GY.Storage
{
    public class StorageComponent : UnturnedPlayerComponent
    {
        private InteractableStorage _storage;
        private Transform _storageTransform;
        private byte[] _state;
        
        protected override void Load()
        {
            _state = DataBaseHelper.GetState(Player.CSteamID).State;
            _storageTransform = BarricadeTool.getBarricade(Player.Player.transform, 100, Player.Position, default, 328, _state);
            _storage = _storageTransform.GetComponent<InteractableStorage>();
        }
        
        public void OpenStorage()
        {
            if (Player.Inventory.isStorageTrunk || Player.Inventory.isStoring || Player.CurrentVehicle != null)
            {
                UnturnedChat.Say(Player,Instance.Translate("storage_block"), Color.red);
                return;
            }

            var best = Utils.BestFit(Player);
            
            if (best == null)
            {
                UnturnedChat.Say(Player, Instance.Translate("storage_not_allow"), Color.red);
                return;
            }
            
            _storage.items.resize(best.Width, best.Height);
            _storage.onStateRebuilt = OnStateRebuilt;
            Player.Inventory.storage = _storage;
            Player.Inventory.storage.opener = Player.Player;
            Player.Inventory.updateItems(PlayerInventory.STORAGE, _storage.items);
            Player.Inventory.sendStorage();
        }
        

        private void OnStateRebuilt(InteractableStorage storage, byte[] state, int size)
        {
            if (storage.transform != _storage.transform) return;
            _state = new byte[size];
            Array.Copy(state, _state, size);
            DataBaseHelper.SetState(Player.CSteamID, _state);
        }
    }
}