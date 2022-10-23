using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static Domain.Constants.Constants;

namespace Domain.Constants
{
    public class Constants
    {

        public enum RuleTypes
        {
            Temparature = 1,
            Weather = 2
        }

        public enum OrderTypes
        {
            Asc = 1,
            Desc = 2
        }

        public enum StatusCodes
        {
            Passive = 0,
            Active = 1
        }
		
        public enum ActionTypes
        {
            Create = 0,
            Update = 2,
            List = 3,
            Error = 4,
            Delete = 5
        }
		
        public enum UserTypes
        {
            User = 0,
            Admin = 1,
            ReportUser = 2
        }
    }
}
