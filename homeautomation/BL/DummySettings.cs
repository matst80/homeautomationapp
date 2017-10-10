using System;
using homeautomation.Interfaces;

namespace homeautomation.BL
{
    internal class DummySettings : ISettings
    {
        public string HostUrl { get; set; } = "fw.knatofs.se";
        public int MqttPort { get; set; } = 1884;
        public int HttpApiPort { get; set; } = 3000;
        public string DeviceOwnerName { get; set; } = "Mats";
        public Uri WebSocketUri { get; set; } = new Uri("ws://fw.knatofs.se:8001");
    }
}