using Models.Time;
using TMPro;
using Utils;

namespace Presenters.UI.Clocks.TimeText
{
    public class TimeTextPresenter
    {
        private readonly TimeModel _timeModel;
        private readonly TMP_Text _text;

        public TimeTextPresenter(TimeModel timeModel, TMP_Text text)
        {
            InvariantChecker.CheckObjectInvariant<TimeTextPresenter>(timeModel,text);

            _timeModel = timeModel;
            _text = text;
        }

        public void Enable()
        {
            _timeModel.TimeUpdated += OnTimeUpdated;
        }

        public void Disable()
        {
            _timeModel.TimeUpdated -= OnTimeUpdated;
        }

        private void OnTimeUpdated()
        {
            _text.text = $"{_timeModel.Time.Hour}:{_timeModel.Time.Minute}:{_timeModel.Time.Second}";
        }
    }
}