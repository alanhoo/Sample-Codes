using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class ApplicantDatabase
    {
        private static List<Application> _applicants = new List<Application>();

        public List<Application> GetAll()
        {
            return _applicants;
        }

        public void Add(Application newapplicant)
        {
            if (_applicants.Any())
            {
                newapplicant.applicantId = _applicants.Max(c => c.applicantId) + 1;
            }
            else
            {
                newapplicant.applicantId = 1;
            }

            _applicants.Add(newapplicant);
        }

        public void Edit(Application application)
        {
            _applicants.RemoveAll(c => c.applicantId == application.applicantId);
            _applicants.Add(application);
            _applicants = _applicants.OrderBy(c => c.applicantId).ToList();
        }

        public void Delete(int id)
        {
            _applicants.RemoveAll(c => c.applicantId == id);
        }

        public Application GetById(int id)
        {
            return _applicants.FirstOrDefault(c => c.applicantId == id);
        }
    }
}
