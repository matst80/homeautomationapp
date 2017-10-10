using System;

namespace homeautomation.Interfaces
{
    public interface ISettings
    {
        string HostUrl { get; set; }
        int MqttPort { get; set; }
        int HttpApiPort { get; set; }
        string DeviceOwnerName { get; set; }
        Uri WebSocketUri { get; set; }
    }
}