using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contoso.Models;

namespace Contoso.Controllers
{
    public class BranchInfo
    {
        BookingSystem db = new BookingSystem();
        public IEnumerable<string> GetAllBranchNames()
        {
            var docs = (from bran in db.Branches
                        select bran.Address);
            return docs.ToList();
        }
    }
}