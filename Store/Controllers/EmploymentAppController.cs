using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class EmploymentAppController
    {
        private EmploymentAppRepository employmentAppRepository;

        public EmploymentAppController(stuff_shopContext db)
        {
            employmentAppRepository = new EmploymentAppRepository(db);
        }

        public EmploymentApp GetEmploymentApp(Person user)
        {
            return employmentAppRepository.GetByUser(user);
        }

        public void AddEmploymentApp(EmploymentApp employmentApp)
        {
            employmentAppRepository.Add(employmentApp);
        }

        public List<EmploymentApp> GetWaitingEmpApps()
        {
            return employmentAppRepository.GetWaiting().ToList();
        }

        public List<EmploymentApp> GetAppsForHR(Person hr)
        {
            return employmentAppRepository.GetForHR(hr).ToList();
        }

        public void UpdateEmpApp(EmploymentApp empApp)
        {
            employmentAppRepository.Update(empApp);
        }

        public void RemoveEmploymentApp(int id)
        {
            employmentAppRepository.Remove(id);
        }

        public EmploymentApp GetEmploymentApp(int id)
        {
            return employmentAppRepository.Get(id);
        }
    }
}
