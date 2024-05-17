using GravitonEcoCoreService.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Controller
{
    public class SensorService
    {
        private readonly Managers.ApplicationContext _context;

        public SensorService()
        {
            _context = new Managers.ApplicationContext();
        }

        public async Task<bool> CreateSensorAsync(SensorBase sensorBase)
        {
            try
            {
                await _context.Sensor.AddAsync(sensorBase);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CreateEntity(object entity)
        {
            using (Managers.ApplicationContext db = new Managers.ApplicationContext())
            {
                db.Add(entity);
                try
                {
                    db.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
                {
                    
                }
            }
        }
    }
}
