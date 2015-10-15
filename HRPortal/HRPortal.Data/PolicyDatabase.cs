using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class PolicyDatabase
    {
        private static List<Policy> _policies = new List<Policy>();

        public List<Policy> GetPolicies()
        {
            return _policies;
        }

        public void AddPolicy(Policy newpolicy)
        {
            _policies.Add(newpolicy);
        }

        public List<Policy> GetListOfPolicies(List<string> titles)
        {
            List<Policy> policies = new List<Policy>();

            foreach (var title in titles)
            {
                Policy policy = GetByTitle(title);
                policies.Add(policy);
            }

            return policies;
        }

        public List<Policy> GetPolicyByCategory(string category)
        {
            var results = from i in _policies
                where i.Category.categoryName == category
                select i;

            return results.ToList();

        } 

        public void DeletePolicy(string title)
        {
            _policies.RemoveAll(p => p.PolicyTitle == title);
        }

        public Policy GetByTitle(string title)
        {
            return _policies.FirstOrDefault(p => p.PolicyTitle == title);
        }

        public string GetCategoryOfPolicy(string title)
        {
            Policy policy = _policies.Find(i => i.PolicyTitle == title);

            return policy.Category.categoryName;
        }

    }
}
