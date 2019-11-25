using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    enum ActivityType
    {
        Air,
        Water,
        Land
    }
    class Activity : IComparable
    {
        public string Name { get; set; }

       
        public DateTime ActivityDateTime { get; set; }
     


        public decimal Cost { get; set; }

        private string _description { get; set; }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                string str = Cost.ToString("0.00");
                string str2 = _description + "" + str;
                str2 = value;
            }
        }

        public Activity(string name,DateTime activityDateTime,decimal cost,string description)
        {
            Name = name;
            ActivityDateTime = activityDateTime;
            Cost = cost;
            Description = description;
        }

        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;

            return this.ActivityDateTime.CompareTo(that.ActivityDateTime);
        }

        public override string ToString()
        {
            string activityDate = ActivityDateTime.ToShortDateString();
            return $"{Name} - {Cost} - {activityDate}";
        }

        public string DescriptionString()
        {
            return Description;
        }
    }
}
