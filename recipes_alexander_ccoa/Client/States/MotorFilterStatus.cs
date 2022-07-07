
using Microsoft.AspNetCore.Components;
using recipes_alexander_ccoa.Shared.Services;

namespace recipes_alexander_ccoa.Client.States
{
    public class MotorFilterStatus
    {
        private MotorFilterModel model;

        private readonly HttpService http;

        public bool loading;
        public bool error;

        public MotorFilterStatus(HttpService http)
        {
            this.http=http;
            model=new MotorFilterModel();
            Task.Run(UpdateMotors);
        }

        public async Task UpdateMotors()
        {
            loading=true;
            error=false;
            model.motors = await http.Run<IEnumerable<string>>("api/motors", HttpMethod.Get, null);

            loading = false;

            if (model.motors != null)
            {
                model.motorSelected = model.motors.FirstOrDefault();
                StateEvent.Invoke(null, model);
                error=false;
            }
            else error = true;
        }

        public async Task<MotorFilterModel> GetStatus() => model;

        public void SetStatus(MotorFilterModel status)
        {
            model = status;
        }

        public void SetStatus(string _motor , DateTime _start, DateTime _end)
        {
            model.Start = _start;
            model.End = _end;
            model.motorSelected = _motor;

            StateEvent.Invoke(null, model);
        }


        public EventHandler<MotorFilterModel> StateEvent { get; set; }

    }

    public class MotorFilterModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string motorSelected { get; set; }
        public IEnumerable<string> motors { get; set; }

        public MotorFilterModel()
        {
            Start = DateTime.Now.Date.AddDays(1);
            End = Start.AddDays(-1);
        }
    }
}
