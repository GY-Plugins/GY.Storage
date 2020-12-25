using System.Collections.Generic;
using Rocket.API;

namespace GY.Storage
{
    public class Config : IRocketPluginConfiguration
    {
        public List<StorageOption> StorageOptions;
        public bool BestStorageForAdmin;
        public void LoadDefaults()
        {
            BestStorageForAdmin = true;
            StorageOptions = new List<StorageOption>
            {
                new StorageOption
                {
                    StorageName = "VIP", Permission = "gy.storage.vip", Height = 5, Width = 5
                },
                new StorageOption
                {
                    StorageName = "ADMIN", Permission = "gy.storage.admin", Height = 7, Width = 7
                },
                new StorageOption
                {
                    StorageName = "PREMIUM", Permission = "gy.storage.premium", Height = 10, Width = 10
                }
            };
        }
        
    }

    public class StorageOption
    {
        public string StorageName { get; set; }
        public string Permission { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
    }
}