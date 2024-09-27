using System;
using Models.DownloadedJson;
using Models.Time;
using Newtonsoft.Json.Linq;
using Utils;

namespace Presenters.JsonToDateTimeParser
{
    public class JsonToDateTimeParserService : IDisposable
    {
        private readonly DownloadedJsonModel _jsonModel;
        private readonly TimeModel _timeModel;

        public JsonToDateTimeParserService(DownloadedJsonModel jsonModel, TimeModel timeModel)
        {
            InvariantChecker.CheckObjectInvariant<JsonToDateTimeParserService>(jsonModel,timeModel);

            _jsonModel = jsonModel;
            _timeModel = timeModel;

            _jsonModel.NewDataDownloaded += OnNewDataDownloaded;
        }

        private void OnNewDataDownloaded()
        {
            Parse();
        }

        private void Parse()
        {
            JObject json = JObject.Parse(_jsonModel.Json);
            var milliseconds = (long)json["time"];
            
            DateTime dateTimeUtc = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).UtcDateTime;
            
            TimeZoneInfo moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, moscowTimeZone);
            
            _timeModel.SynchronizeTime(moscowTime);
        }

        public void Dispose()
        {
            _jsonModel.NewDataDownloaded -= OnNewDataDownloaded;
        }
    }
}